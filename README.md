# Windows classification App
## 建立自訂視覺資源和專案

### 建立自訂視覺資源
若要使用自訂視覺服務，您必須在 Azure 中建立自訂視覺資源。
1. 註冊 Azure 帳戶，至主頁面選取 create a resource。

![image](https://user-images.githubusercontent.com/59305013/146176173-6de5b2e7-c392-458f-a8e6-3aae47dfaeb2.png)

2. 在搜尋方塊中，搜尋Custom Vison，進入後選取Create Custom Vision 即可在[建立自訂視覺] 頁面上開啟對話方塊視窗。

![image](https://user-images.githubusercontent.com/59305013/146176213-54c7dc17-9fc4-45b6-87a5-bd3eaffc87ea.png)

3. 在 [自訂視覺] 對話方塊頁面上，選擇下列各項：
* 選取 Training 和 Prediction 資源。
* 選取訂用帳戶以管理已部署的資源。 如果您在功能表中看不到您的 Azure 訂用帳戶，請使用您開啟帳戶時所用的相同認證來登出並重新開啟您的 Azure 帳戶。
* 建立新的資源群組，並為其命名。 在本教學課程中，我們呼叫了我們 MLTraining ，但您可以選擇使用自己的名稱，或使用現有的資源群組（如果有的話）。
* 為專案命名。 在本教學課程中，我們呼叫了我們 classificationApp ，但您可以使用您選擇的任何名稱。
* 針對 Training 和 Prediction 資源，請將位置設定為 Training和 Prediction （ 免費）。
4. 按下 Review + create 以部署您的自訂視覺資源。 部署資源可能需要幾分鐘的時間。

![image](https://user-images.githubusercontent.com/59305013/146168472-8dafffa9-6272-44a9-ad22-8cc8ab668c47.png)

## 在自訂視覺中建立新專案
既然您已建立資源，現在可以在自訂視覺中建立定型專案。

1. 在您的網頁瀏覽器中，流覽至 [ 自訂視覺 ]  頁面，然後選取 [] 。 請使用您用來登入 Azure 入口網站的相同帳戶進行登入。
[自訂視覺]: https://www.customvision.ai/projects/2f3346f3-4d11-48d8-ae21-607671669517#/manage
2. 選取 New Project 以開啟 [新增專案] 對話方塊。

![image](https://user-images.githubusercontent.com/59305013/146168722-03bd8c04-bc3f-481f-b7cc-0b27b89b1bfb.png)

3. 建立新的專案，如下所示：
* Name: FoodClassification.
* Description：分類不同類型的食物。
* Resource：保留您先前開啟的相同資源– ClassificationApp [F0] 。
* Project Types: classification
* Classification Types: Multilabel (Multiple tags per image)
* Domains: Food (compact).
* Export Capabilities: Basic platforms (Tensorflow, CoreML, ONNX, ...)

**注意: 若要匯出為 ONNX 格式，請確定您選擇的是 Food (compact) 網域。 非 compact 網域無法匯出至 ONNX。**
**重要: 如果您登入的帳戶與 Azure 帳戶相關聯，[資源群組] 下拉式清單會顯示所有的 Azure 資源群組，包括自訂視覺服務資源。 如果沒有可用的資源群組，請確認您已使用與登入 Azure 入口網站相同的帳戶登入 customvision.ai。**
4. 填妥對話方塊之後，請選取 [] Create project 。

![image](https://user-images.githubusercontent.com/59305013/146168887-105b1937-5ab2-4d95-941f-5f38226df62d.png)

### Upload 訓練資料集
現在您已建立專案，您將會從 Kaggle 開啟的資料集上傳先前備妥的食物影像資料集。
1. 選取您的 FoodClassification 專案，以開啟自訂視覺網站的 web 介面。
2. 選取 Add images 按鈕，然後選擇 [] Browse local files 。

![image](https://user-images.githubusercontent.com/59305013/146168992-bebaf22d-0242-4a33-9af7-3305f01317e4.png)

3. 流覽至影像資料集的位置，然後選取定型資料夾– vegetable-fruit 。 選取資料夾中的所有影像，然後選取 [] open 。 將會開啟標記選項。
4. vegetable-fruit在欄位中輸入 My Tags ，然後按下 Upload 。

![image](https://user-images.githubusercontent.com/59305013/146169060-3078460e-08a2-4699-a7c3-35c405f2dfdd.png)

等候第一個影像群組上傳至您的專案，然後按下 done 。 標記選取將套用到您選取要上傳的整個影像群組。 這就是為什麼從已經預先建立的映射群組上傳影像更容易。 在上傳個別影像之後，您隨時都可以變更這些標記。

![image](https://user-images.githubusercontent.com/59305013/146169091-bb897906-9972-45d9-850e-767095622f24.png)

5. 在成功上傳第一個影像群組之後，重複此程式兩次以上，以上傳甜點和 < a0 的影像。 請確定您已使用相關的標記標記。
最後，您會有三個不同的映射群組可供定型。

![image](https://user-images.githubusercontent.com/59305013/146169152-53edc72e-e3f1-4b47-a04a-3805b7a568f8.png)

### 定型模型分類器
您現在會將模型定型，以從您在上一個部分下載的影像集合中分類蔬菜、湯 和甜點。
1. 若要開始訓練流程，請選取 Train 右上角的按鈕。 分類器會使用影像來建立模型，以識別每個標記的視覺品質。

![image](https://user-images.githubusercontent.com/59305013/146169271-cf01e2e3-b884-4afa-9265-89665bab0802.png)

您可以使用左上角的滑杆來變更機率臨界值的選項。 機率臨界值會設定預測必須有才能被視為正確的信賴等級。 如果機率臨界值過高，您將會得到更正確的分類，但會偵測到較少。 另一方面，如果機率閾值太低，您將會偵測到更多分類，但會有較低的信賴度或更高的誤報結果。

在本教學課程中，您可以將機率閾值保持在50%。
2. 在這裡，我們將使用此程式 Quick Training 。 Advanced Training 有更多的設定，可讓您特別設定用於定型的時間，但我們不需要此層級的控制。 按 Train 以起始定型流程。

![image](https://user-images.githubusercontent.com/59305013/146169336-42d12ac0-2a6d-4b20-abac-e4932213d111.png)

快速定型程式只需要幾分鐘的時間就能完成。 在這段期間，定型程式的相關資訊會顯示在索引標籤中 Performance 。

![image](https://user-images.githubusercontent.com/59305013/146169357-fb36ef7a-7908-494c-898e-d9bbba399277.png)

## 評估和測試
### 評估結果
定型完成後，您會看到第一個定型反復專案的摘要。 它包含模型效能的估計– 精確度 和 召回率。

* 精確度表示識別的正確分類所得到的分數。 在我們的模型中，有效位數是98.2%，因此，如果我們的模型會將影像分類，則很可能會正確地預測。
* 回收表示正確識別實際分類所得到的分數。 在我們的模型中，召回率為97.5%，因此我們的模型會適當地將大部分呈現的影像分類。
* AP 代表額外的效能。 這會提供額外的度量，以摘要說明不同閾值的精確度和召回率。

![image](https://user-images.githubusercontent.com/59305013/146169602-1bec35ad-87e9-43c8-9c5b-d82f23dc902a.png)

### 測試模型
在匯出模型之前，您可以測試其效能。

1. 選取 Quick Test 頂端功能表列右上角的，以開啟新的測試視窗。

![image](https://user-images.githubusercontent.com/59305013/146169666-cfd60ccb-443e-4b95-bbe5-4a3fccaf687f.png)

在此視窗中，您可以提供要測試之影像的 URL，或選取 Browse local files 以使用儲存在本機的影像。

![image](https://user-images.githubusercontent.com/59305013/146169737-50a136f2-6f46-401c-b455-218a8120bd86.png)

2. 選擇 Browse local files 、流覽至食物資料集，然後開啟驗證資料夾。 從資料夾選擇任何隨機影像 fruit-vegetable ，然後按下 open 。

![image](https://user-images.githubusercontent.com/59305013/146169778-8c6d2174-f7bf-4ce8-8c48-c9c8da6713a5.png)

測試的結果會顯示在畫面上。 在我們的測試中，此模式已成功將映射分類為99.8% 的確定性。

![image](https://user-images.githubusercontent.com/59305013/146169832-1eee9d66-6820-48b7-92f1-e27bce73702c.png)

您可以在索引標籤中使用預測來定型 Predictions ，這樣可以改善模型效能。 如需詳細資訊，請參閱 如何改進您的分類器。

**注意: 有興趣深入瞭解 Azure 自訂視覺 Api 嗎？ 自訂視覺服務檔包含自訂視覺入口網站和 SDK 的詳細資訊。**

## 將模型匯出至 ONNX
既然我們已將模型定型，我們可以將它匯出至 ONNX。
1. 選取 [] 索引標籤 Performance ，然後選擇 Export 開啟 [匯出] 視窗。

![image](https://user-images.githubusercontent.com/59305013/146169996-1e7bd0ec-d016-4aa3-8528-59971226f7f6.png)

2. 選取 ONNX 即可將您的模型匯出為 ONNX 格式。

![image](https://user-images.githubusercontent.com/59305013/146170034-2f24174b-dbca-4d62-90d6-9e09a88d90fb.png)

3. ONNX 16如有必要，您可以選擇 float 選項，但是在本教學課程中，我們不需要變更任何設定。 選取 Export and Download。

![image](https://user-images.githubusercontent.com/59305013/146170069-1a4cd6f6-a308-47b5-bbc4-c867e23a1363.png)

4. 開啟已下載的 .zip 檔案，並 model.onnx 從中解壓縮檔案。 此檔案包含您的分類器模型。
您已成功建立並匯出分類模型。

# 使用 Windows 機器學習 api 在 Windows 應用程式中部署模型
完成一個工作影像分類器 WinML UWP 應用程式 (c # ) 。

## 關於範例應用程式
使用我們的模型，我們將建立可分類食物影像的應用程式。 它可讓您從本機裝置選取影像，並使用您 在上一個部分中建立和定型的本機儲存的分類 ONNX 模型來處理它。 傳回的標記會顯示在影像旁邊，以及分類的信賴機率。

**注意: 如果您想要下載完整的範例程式碼，您可以複製 方案檔。 複製儲存機制，流覽至此範例，然後 ImageClassifierAppUWP.sln 以 Visual Studio 開啟檔案。 然後，您可以跳到應用程式) 步驟中的 [啟動應用程式] (#Launch。**

## 建立 WinML UWP (c # )
以下我們將示範如何從頭開始建立應用程式和 WinML 程式碼。 您將學習如何：
* 載入機器學習模型。
* 載入所需格式的影像。
* 系結模型的輸入和輸出。
* 評估模型並顯示有意義的結果。
您也會使用基本 XAML 來建立簡單的 GUI，讓您可以測試影像分類器。

### 建立應用程式
1. 開啟 Visual Studio，然後選擇 create a new project 。

![image](https://user-images.githubusercontent.com/59305013/146177158-a8ffef16-758d-4c30-b92f-7406f1618aef.png)

2. 在搜尋列中，輸入 UWP ，然後選取 [ Blank APP (Universal Windows) ]。 這會針對沒有預先定義的控制項或配置的單一頁面通用 Windows 平臺 (UWP) 應用程式開啟新的 c # 專案。 選取 Next 即可開啟專案的設定視窗。

![image](https://user-images.githubusercontent.com/59305013/146177200-ad8a3282-f692-4ae1-90e9-a2ce9b39d96b.png)

3. 在 [設定] 視窗中：
* 選擇專案的名稱。 在這裡，我們會使用 ImageClassifierAppUWP。
* 選擇專案的位置。
* 如果您使用 VS 2019，請確定 Place solution and project in the same directory 未核取。
* 如果您正在使用 VS 2017，請確定 Create directory for solution 已核取。
按下 create 以建立您的專案。 最小的 [目標版本] 視窗可能會出現。 請確定您的最小版本已設定為Windows 10 組建 17763或更新版本。

若要建立應用程式並使用 WinML 應用程式部署模型，您需要下列各項：
4. 建立專案之後，流覽至專案資料夾，開啟 [資產] 資料夾 [.. ..\ImageClassifierAppUWP\Assets]，並將您的模型複製到這個位置。
5. 將模型名稱從變更 model.onnx 為 classifier.onnx 。 這可讓事情變得更清楚，並將其與教學課程的格式對齊。

### 探索您的模型(可忽略)
讓我們熟悉模型檔的結構。
1. 使用 Neutron 開啟您的 classifier.onnx 模型檔案 classifier.onnx
2. 按 Data 以開啟模型屬性。

![image](https://user-images.githubusercontent.com/59305013/146177428-4ee99197-bdd2-4d77-8e07-7e81e0868026.png)

如您所見，模型需要32位 Tensor (多維度陣列) float 物件做為輸入，並傳回兩個輸出：第一個名為 classLabel Tensor 的字串，而第二個名為的 loss 字串與浮點數對應的序列，其描述每個標示分類的機率。 您將需要這項資訊，才能成功地在 Windows 應用程式中顯示模型輸出。

### 探索專案方案
讓我們來探索您的專案解決方案。

Visual Studio 在方案總管內自動建立數個 cs 程式碼檔案。 MainPage.xaml 包含您 GUI 的 XAML 程式碼， MainPage.xaml.cs 包含您的應用程式程式碼。 如果您之前已建立 UWP 應用程式，則應該非常熟悉這些檔案。

## 建立應用程式 GUI
首先，讓我們為您的應用程式建立簡單的 GUI。
1. 按兩下檔案 MainPage.xaml 。 在您的空白應用程式中，應用程式 GUI 的 XAML 範本是空的，因此我們必須新增一些 UI 功能。
2. 將下列程式碼新增至的主體 MainPage.xaml 。

'''
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">

        <StackPanel Margin="1,0,-1,0">
            <TextBlock x:Name="Menu" 
                       FontWeight="Bold" 
                       TextWrapping="Wrap"
                       Margin="10,0,0,0"
                       Text="Image Classification"/>
            <TextBlock Name="space" />
            <Button Name="recognizeButton"
                    Content="Pick Image"
                    Click="OpenFileButton_Click" 
                    Width="110"
                    Height="40"
                    IsEnabled="True" 
                    HorizontalAlignment="Left"/>
            <TextBlock Name="space3" />
            <Button Name="Output"
                    Content="Result is:"
                    Width="110"
                    Height="40"
                    IsEnabled="True" 
                    HorizontalAlignment="Left" 
                    VerticalAlignment="Top">
            </Button>
            <!--Display the Result-->
            <TextBlock Name="displayOutput" 
                       FontWeight="Bold" 
                       TextWrapping="Wrap"
                       Margin="30,0,0,0"
                       Text="" Width="1471" />
            <Button Name="ProbabilityResult"
                    Content="Probability is:"
                    Width="110"
                    Height="40"
                    IsEnabled="True" 
                    HorizontalAlignment="Left"/>
            <!--Display the Result-->
            <TextBlock Name="displayProbability" 
                       FontWeight="Bold" 
                       TextWrapping="Wrap"
                       Margin="30,0,0,0"
                       Text="" Width="1471" />
            <TextBlock Name="space2" />
            <!--Image preview -->
            <Image Name="UIPreviewImage" Stretch="Uniform" MaxWidth="300" MaxHeight="300"/>
        </StackPanel>
    </Grid>
'''

## Windows 機器學習程式碼產生器
Windows 機器學習程式碼產生器（或mlgen）是一種 Visual Studio 延伸模組，可協助您開始在 UWP 應用程式上使用 WinML api。 當您將定型的 ONNX 檔新增至 UWP 專案時，它會產生範本程式碼。

Windows 機器學習的程式碼產生器 mlgen 會建立 c #、c + +/WinRT 和 c + +) /cx 的介面 (，並以包裝函式類別為您呼叫 Windows ML API。 這可讓您輕鬆地在專案中載入、系結和評估模型。 我們將在本教學課程中使用它來為我們處理許多函數。

程式碼產生器適用于 Visual Studio 2017 和更新版本。 請注意，在 Windows 10 1903 版和更新版本中，mlgen 已不再隨附于 Windows 10 SDK，因此您必須下載並安裝延伸模組。 如果您已遵循本教學課程中的教學課程，您將會處理此動作，但如果不是，您應該下載 vs 2019 或 for vs 2017。
**注意: 若要深入瞭解 mlgen，請參閱 mlgen 檔**

1. 如果您還沒有這麼做，請安裝 mlgen。
2. Assets Visual studio 中，以滑鼠右鍵按一下方案總管中的資料夾，然後選取 [] Add > Existing Item 。
3. 流覽至內的 [資產] 資料夾 ImageClassifierAppUWP [….\ImageClassifierAppUWP\Assets] ，找出您先前複製到該處的 ONNX 模型，然後選取 [] add 。
4. 在您將 ONNX 模型新增 (名稱： "分類器" ) 至 VS 中 [方案] 中的 [資產] 資料夾，專案現在應該有兩個新的檔案：
* classifier.onnx -這是您的 ONNX 格式模型。
* classifier.cs –自動產生的 WinML 程式碼檔案。

![image](https://user-images.githubusercontent.com/59305013/146177791-7ef6b398-e23f-4fa7-9cb3-b03b89c45e3f.png)

5. 若要確定您在編譯應用程式時所建立的模型，請選取該檔案， classifier.onnx 然後選擇 Properties 。 針對 Build Action，選取 Content。
現在，讓我們來探索分類 .cs 檔案中新產生的程式碼。
產生的程式碼包含三個類別：
* classifierModel：此類別包含兩個模型具現化和模型評估的方法。 它將協助我們建立機器學習模型標記法、在系統預設裝置上建立會話、將特定輸入和輸出系結至模型，並以非同步方式評估模型。
* classifierInput：這個類別會初始化模型所預期的輸入類型。 模型輸入取決於輸入資料的模型需求。 在我們的案例中，輸入預期會有一個 ImageFeatureValue，這是一個類別，描述用來傳遞至模型的影像屬性。
* classifierOutput：這個類別會初始化模型將輸出的類型。 模型輸出取決於模型的定義方式。 在我們的案例中，輸出會是一系列的地圖 (字典) ，其為字串類型，而 TensorFloat (Float32) 稱為「遺失」。

您現在將使用這些類別，在專案中載入、系結和評估模型。

## 載入模型 & 輸入
### 載入模型
1. 按兩下程式碼檔案 MainPage.xaml.cs 以開啟應用程式程式碼。
2. 將 "using" 語句取代為下列各項，以取得您需要的所有 Api 的存取權。
'''
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
'''
3. 在命名空間底下的類別內使用語句之後，新增下列變數宣告 MainPageImageClassifierAppUWP 。
'''
// All the required variable declaration
        private classifierModel modelGen;
        private classifierInput input = new classifierModelInput();
        private classifierOutput output;
        private StorageFile selectedStorageFile;
        private string result = "";
        private float resultProbability = 0;
'''
結果看起來會如下所示。
'''
// Specify all the using statements which give us the access to all the APIs that we'll need
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

namespace ImageClassifierAppUWP
{
    public sealed partial class MainPage : Page
    {
        // All the required fields declaration
        private classifierModel modelGen;
        private classifierInput input = new classifierInput();
        private classifierOutput output;
        private StorageFile selectedStorageFile;
        private string result = "";
        private float resultProbability = 0;
'''
現在，您將會執行 LoadModel 方法。 方法會存取 ONNX 模型，並將它儲存在記憶體中。 然後，您將使用方法，將模型具現 CreateFromStreamAsync 化為 LearningModel 物件。 LearningModel類別代表已定型的機器學習模型。 一旦具現化後， LearningModel 就是您用來與 Windows ML 互動的初始物件。

若要載入模型，您可以使用類別中的數個靜態方法 LearningModel 。 在此情況下，您將會使用 CreateFromStreamAsync 方法。

CreateFromStreamAsync方法是使用 mlgen 自動建立的，因此您不需要執行此方法。 您可以按兩下 [檔案產生的檔案（依 mlgen）] 來檢查此方法 classifier.cs 。

若要深入瞭解 LearningModel 類別，請參閱 LearningModel。 若要深入瞭解載入模型的其他方式，請參閱 載入模型檔
4. 將 loadModel 方法加入至 MainPage.xaml.cs 類別內的程式碼檔案 MainPage 。
'''
private async Task loadModel()
        {
            // Get an access the ONNX model and save it in memory.
            StorageFile modelFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri($"ms-appx:///Assets/classifier.onnx"));
            // Instantiate the model. 
            modelGen = await classifierModel.CreateFromStreamAsync(modelFile);
        }
'''
5. 現在，將新方法的呼叫加入至類別的函式。
'''
// The main page to initialize and execute the model.
        public MainPage()
        {
            this.InitializeComponent();
            loadModel();
        }
'''
結果看起來會如下所示。
'''
// The main page to initialize and execute the model.
        public MainPage()
        {
            this.InitializeComponent();
            loadModel();
        }

        // A method to load a machine learning model.
        private async Task loadModel()
        {
            // Get an access the ONNX model and save it in memory.  
            StorageFile modelFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri($"ms-appx:///Assets/classifier.onnx"));
            // Instantiate the model. 
            modelGen = await classifierModel.CreateFromStreamAsync(modelFile);
        }
'''
### 載入映射
1. 我們必須定義 click 事件，才能起始模型執行的四個方法呼叫的序列–轉換、系結和評估、輸出解壓縮，以及顯示結果。 將下列方法新增至 MainPage.xaml.cs 類別內的程式碼檔案 MainPage 。
'''
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
'''
2. 現在，您將會執行 getImage() 方法。 這個方法會選取輸入影像檔案，並將它儲存在記憶體中。 將下列方法新增至 MainPage.xaml.cs 類別內的程式碼檔案 MainPage 。
'''
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
'''
  
現在，您將會實作為 Bind() 點陣圖 BGRA8 格式取得檔案標記法的影像方法。
  
3. 將方法的實作為 convert()MainPage.xaml.cs MainPage 類別內的程式碼檔案。 Convert 方法會以 BGRA8 格式取得輸入檔的標記法。
'''
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
'''
在本節中完成的工作結果將如下所示。
'''
// Waiting for a click event to select a file 
        private async void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (!await getImage())
            {
                return;
            }
            // After the click event happened and an input selected, we begin the model execution. 
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
'''
  
## 系結和評估模型
接下來，您將建立以模型為基礎的會話、系結會話的輸入和輸出，以及評估模型。
###  建立用來系結模型的會話：
若要建立會話，您可以使用 LearningModelSession 類別。 這個類別是用來評估機器學習模型，並將模型系結到接著執行和評估模型的裝置。 您可以在建立會話時選取裝置，以在電腦的特定裝置上執行您的模型。 預設裝置為 CPU。
**注意: 若要深入瞭解如何選擇裝置，請參閱 建立會話 檔。**

## 系結模型輸入和輸出：
  若要系結輸入和輸出，請使用 LearningModelBinding 類別。 機器學習模型具有輸入和輸出功能，可將資訊傳入和傳出模型。 請注意，windows ML api 必須支援所需的功能。 LearningModelBinding類別會套用 LearningModelSession 至，以將值系結至命名的輸入和輸出功能。

Mlgen 會自動產生系結的執行，因此您不需要加以處理。 系結是透過呼叫類別的預先定義方法來執行 LearningModelBinding 。 在我們的案例中，它會使用 Bind 方法將值系結至指定的功能類型。

目前，Windows ML 支援所有 ONNX 功能類型，例如張量 (多維度陣列) 、序列 (值的向量) 、對應 (的資訊) 值組 (和) 特定格式的影像。 所有映射將以 tensor 格式以 Windows ML 表示。 Tensorization 是將影像轉換成 tensor 並在系結期間發生的程式。

幸運的是，您不需要負責 tensorization 轉換。 ImageFeatureValue您在前一個部分中使用的方法會同時負責轉換和 tensorization，因此影像會符合模型的必要影像格式。
**注意: 若要深入瞭解如何系結 LearningModel 和 WinML 所支援的功能類型，請參閱系結 LearningModel 檔。**
  
### 評估模型：
  
