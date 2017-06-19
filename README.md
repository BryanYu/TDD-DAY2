# 91的TDD-8th

## 預計的學習目標

1. 我希望未來再開發Code的時候能夠思考「好測試」的這件事
2. 我希望我自己學完之後能夠將「測試通過才算是完成的」的觀念帶給團隊成員
3. 我希望能夠學習到單元測試、整合測試、Live Document的相關技巧，並能夠整合進CI/CD，降低手工工作的工作量
4. 我希望能夠從測試開始，建立良好的團隊文化，不要再寫一些用人格保證沒問題的Code

# DAY2上課心得

1. 學習如何使用Selenium IDE(FireFox plugin)錄製在Web上的自動化操作案例
2. 利用Selenium IDE的Export功能，匯出為多種程式語言能夠執行的測試案例(上課以MsTests為例)
3. 利用FluentAutomation套件，將Web自動化測試案例改寫成語意較為明顯的測試案例(以I開頭，搭配CSS selector來操作網頁)
4. 利用PageObject套件，以Code來模擬Web上的網頁，將每一個Web Page當成一個PageObject物件，搭配FluentAutomation來撰寫測試
5. 介紹重構的技巧，並練習計算物流運費的案例，將Legacy Code一步步重構成好讀好測試的程式碼 

(自我練習部分)
1. 練習MVC Controller 的Unit Test，關鍵在於Controller回傳的是ActionResult，是MVC Result的基底類別，需要以自己的使用情境去轉型成不同的ActionResult，再來做Assert。
2. MessageHandler的Unit Test，測試是驗證是否為聖誕節，如果是就可以呼叫，不是就回傳Bad Request，範例中使用FakeHandler，成功呼叫時會使用FakeHandler來模擬回傳訊息，失敗的呼叫就直接Reject了，並不會呼叫到FakeHandler
3. 練習了IsolatedByInheritanceAndOverride範例，我的體驗是，這個技巧是利用virtual的特性，並使用子類別來繼承父類別，由子類別來override virtual method，可以做到由繼承的子類別來決定父類別的實作，雖然父類別的method有做一些修正，但不影響現有邏輯。這個範例子類別 override virtual method是用來設定orders的來源物件，切換至測試案例內的dummy Orders，以及BookDao的實作，由NSub模擬的Mock物件。

# HomeWork-DAY2 哈利波特購物車


1. 一到五集的哈利波特，每一本都是賣100元
2. 如果你從這個系列買了兩本不同的書，則會有5%的折扣
3. 如果你買了三本不同的書，則會有10%的折扣
4. 如果是四本不同的書，則會有20%的折扣
5. 如果你一次買了整套一到五集，恭喜你將享有25%的折扣
6. 需要留意的是，如果你買了四本書，其中三本不同，第四本則是重複的，
那麼那三本將享有10%的折扣，但重複的那一本，則仍須100元。

# HomeWork-DAY2心得
這次的作業用紅燈(寫測試案例得到失敗結果)、綠燈(已能通過測試案例為主)、重構的節奏來實作，我覺得最難的部分是在於「重構」，因為要寫怎麼把Code寫得好維護、可讀性高，實在是需要花很多腦筋思考，也因為有測試案例保護，可以放心地作重構，不怕把原有邏輯改壞掉。也因為有進行重構這個步驟，最後得到的程式碼的循環複雜度不超過15，我自己認為是還可以接受的。

PS.試用了一下Resharper 真是有點相見恨晚的感覺
   





