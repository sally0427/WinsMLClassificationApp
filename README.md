# Windows classification App
## 建立自訂視覺資源和專案

### 建立自訂視覺資源
1. 註冊 Azure 帳戶，至主頁面選取 create a resource，
2. 在搜尋方塊中，搜尋Custom Vison，進入後選取Create Custom Vision 即可在[建立自訂視覺] 頁面上開啟對話方塊視窗。
3. 在 [自訂視覺] 對話方塊頁面上，選擇下列各項：
選取 Training 和 Prediction 資源。
選取訂用帳戶以管理已部署的資源。 如果您在功能表中看不到您的 Azure 訂用帳戶，請使用您開啟帳戶時所用的相同認證來登出並重新開啟您的 Azure 帳戶。
建立新的資源群組，並為其命名。 在本教學課程中，我們呼叫了我們 MLTraining ，但您可以選擇使用自己的名稱，或使用現有的資源群組（如果有的話）。
為專案命名。 在本教學課程中，我們呼叫了我們 classificationApp ，但您可以使用您選擇的任何名稱。
針對 Training 和 Prediction 資源，請將位置設定為 Training和 Prediction （ 免費）。
按下 Review + create 以部署您的自訂視覺資源。 部署資源可能需要幾分鐘的時間。

![image](https://user-images.githubusercontent.com/59305013/146168472-8dafffa9-6272-44a9-ad22-8cc8ab668c47.png)

## 在自訂視覺中建立新專案
既然您已建立資源，現在可以在自訂視覺中建立定型專案。

1. 在您的網頁瀏覽器中，流覽至 [ 自訂視覺 ] 頁面，然後選取 [] 。 請使用您用來登入 Azure 入口網站的相同帳戶進行登入。

2. 選取 New Project 以開啟 [新增專案] 對話方塊。

![image](https://user-images.githubusercontent.com/59305013/146168722-03bd8c04-bc3f-481f-b7cc-0b27b89b1bfb.png)

3. 建立新的專案，如下所示：
Name: FoodClassification.
Description：分類不同類型的食物。
Resource：保留您先前開啟的相同資源– ClassificationApp [F0] 。
Project Types: classification
Classification Types: Multilabel (Multiple tags per image)
Domains: Food (compact).
Export Capabilities: Basic platforms (Tensorflow, CoreML, ONNX, ...)

!若要匯出為 ONNX 格式，請確定您選擇的是 Food (compact) 網域。 非 compact 網域無法匯出至 ONNX。
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
2. 
![image](https://user-images.githubusercontent.com/59305013/146169271-cf01e2e3-b884-4afa-9265-89665bab0802.png)

您可以使用左上角的滑杆來變更機率臨界值的選項。 機率臨界值會設定預測必須有才能被視為正確的信賴等級。 如果機率臨界值過高，您將會得到更正確的分類，但會偵測到較少。 另一方面，如果機率閾值太低，您將會偵測到更多分類，但會有較低的信賴度或更高的誤報結果。

在本教學課程中，您可以將機率閾值保持在50%。
2. 在這裡，我們將使用此程式 Quick Training 。 Advanced Training 有更多的設定，可讓您特別設定用於定型的時間，但我們不需要此層級的控制。 按 Train 以起始定型流程。
3. 
![image](https://user-images.githubusercontent.com/59305013/146169336-42d12ac0-2a6d-4b20-abac-e4932213d111.png)

快速定型程式只需要幾分鐘的時間就能完成。 在這段期間，定型程式的相關資訊會顯示在索引標籤中 Performance 。

![image](https://user-images.githubusercontent.com/59305013/146169357-fb36ef7a-7908-494c-898e-d9bbba399277.png)

## 評估和測試
###評估結果
定型完成後，您會看到第一個定型反復專案的摘要。 它包含模型效能的估計– 精確度 和 召回率。

*精確度表示識別的正確分類所得到的分數。 在我們的模型中，有效位數是98.2%，因此，如果我們的模型會將影像分類，則很可能會正確地預測。
*回收表示正確識別實際分類所得到的分數。 在我們的模型中，召回率為97.5%，因此我們的模型會適當地將大部分呈現的影像分類。
*AP 代表額外的效能。 這會提供額外的度量，以摘要說明不同閾值的精確度和召回率。

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


