// Specify all the using statements which give us the access to all the APIs that you'll need
using System;
using System.Threading.Tasks;
using Windows.AI.MachineLearning;
using Windows.Graphics.Imaging;
using Windows.Media;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// 空白頁項目範本已記錄在 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x404

namespace ImageClassifierAppUWP
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // All the required variable declaration
        private classifierModel modelGen;
        private classifierInput input = new classifierInput();
        private classifierOutput output;
        private StorageFile selectedStorageFile;
        private string result = "";
        private float resultProbability = 0;

        // The main page to initialize and execute the model.
        public MainPage()
        {
            this.InitializeComponent();
            loadModel();
        }

        private async Task loadModel()
        {
            // Get an access the ONNX model and save it in memory.
            StorageFile modelFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri($"ms-appx:///Assets/classifier.onnx"));
            // Instantiate the model. 
            modelGen = await classifierModel.CreateFromStreamAsync(modelFile);
        }

        // Waiting for a click event to select a file 
        private async void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (!await getImage())
            {
                return;
            }
            // After the click event happened and an input selected, begin the model execution. 
            // Bind the model input
            await imageBind();
            // Model evaluation
            await evaluate();
            // Extract the results
            extractResult();
            // Display the results  
            await displayResult();
        }

        // A method to select an input image file
        private async Task<bool> getImage()
        {
            try
            {
                // Trigger file picker to select an image file
                FileOpenPicker fileOpenPicker = new FileOpenPicker();
                fileOpenPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
                fileOpenPicker.FileTypeFilter.Add(".jpg");
                fileOpenPicker.FileTypeFilter.Add(".png");
                fileOpenPicker.ViewMode = PickerViewMode.Thumbnail;
                selectedStorageFile = await fileOpenPicker.PickSingleFileAsync();
                if (selectedStorageFile == null)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        // A method to convert and bind the input image.  
        private async Task imageBind()
        {
            UIPreviewImage.Source = null;
            try
            {
                SoftwareBitmap softwareBitmap;
                using (IRandomAccessStream stream = await selectedStorageFile.OpenAsync(FileAccessMode.Read))
                {
                    // Create the decoder from the stream 
                    BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
                    // Get the SoftwareBitmap representation of the file in BGRA8 format
                    softwareBitmap = await decoder.GetSoftwareBitmapAsync();
                    softwareBitmap = SoftwareBitmap.Convert(softwareBitmap, BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied);
                }
                // Display the image
                SoftwareBitmapSource imageSource = new SoftwareBitmapSource();
                await imageSource.SetBitmapAsync(softwareBitmap);
                UIPreviewImage.Source = imageSource;
                // Encapsulate the image within a VideoFrame to be bound and evaluated
                VideoFrame inputImage = VideoFrame.CreateWithSoftwareBitmap(softwareBitmap);
                // bind the input image
                ImageFeatureValue imageTensor = ImageFeatureValue.CreateFromVideoFrame(inputImage);
                input.data = imageTensor;
            }
            catch (Exception e)
            {
            }
        }

        // A method to evaluate the model
        private async Task evaluate()
        {
            output = await modelGen.EvaluateAsync(input);
        }

        private void extractResult()
        {
            // A method to extract output (result and a probability) from the "loss" output of the model 
            var collection = output.loss;
            float maxProbability = 0;
            string keyOfMax = "";

            foreach (var dictionary in collection)
            {
                foreach (var key in dictionary.Keys)
                {
                    if (dictionary[key] > maxProbability)
                    {
                        maxProbability = dictionary[key];
                        keyOfMax = key;
                    }
                }
            }
            result = keyOfMax;
            resultProbability = maxProbability;
        }

        // A method to display the results
        private async Task displayResult()
        {
            displayOutput.Text = result.ToString();
            displayProbability.Text = resultProbability.ToString();
        }
    }
}
