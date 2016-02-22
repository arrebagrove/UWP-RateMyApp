# UWP-RateMyApp

The UWP version of Microsoft's https://github.com/Microsoft/rate-my-app

Targeting Platform
------------
- Windows 10 Build 10586+
- Windows 10 Mobile Build 10586+

Changes to Original RateMyApp Control
------------
- Replace Border control with ContentDialog
- Remove Visiblity Property (Because by using ContentDialog, we no longer need to set the Visibilty of the Feedback Overlay)
- Improve code readability
- Migrate to C#6
- More Chinese like zh-CN lanugage
- Remove Windows 8.1 and Windows Phone 8.x projects

Usage
-----------
<pre>
&lt;Grid x:Name=&quot;LayoutRoot&quot; Background=&quot;{ThemeResource ApplicationPageBackgroundThemeBrush}&quot;&gt;
    &lt;!-- Feedback overlay --&gt;
    &lt;controls:FeedbackOverlay x:Uid=&quot;RMA&quot; 
                x:Name=&quot;FeedbackOverlay&quot;
                Width=&quot;{Binding ElementName=LayoutRoot, Path=Width}&quot;
                FeedbackTo=&quot;Edi.Wang@outlook.com&quot;
                ApplicationName=&quot;Another Funcking App&quot;
                CompanyName=&quot;Superhard&quot;
                FirstCount=&quot;2&quot;
                SecondCount=&quot;4&quot; /&gt;
&lt;/Grid&gt;
</pre>

Senarios
-----------
- Given the app developer set the FirstCount and SecondCount value.
- When user launch the app for the FirstCount time.
- Then a content dialog is shown with two buttons.
- When user click "rate 5 starts" button.
- Then the user is taken to the Windows Store review page of the current app.
- Then the content dialog will never show again.

![First Review](https://raw.githubusercontent.com/EdiWang/UWP-RateMyApp/master/screenshots/screenshot2.png)

- Given the app developer set the FirstCount and SecondCount and FeedbackTo value.
- When user launch the app for the FirstCount time.
- Then a content dialog is shown with two buttons.
- When user click "no thanks" button.
- Then the content dialog will show with title "Can we make it better" and two buttons.
- When the user click "give feedback" button
- Then the default email program will be opened on the device with to address set to FeedbackTo.

![Feedback](https://raw.githubusercontent.com/EdiWang/UWP-RateMyApp/master/screenshots/screenshot1.png)

- Given the user has clicked the "no thanks" button for the first two times.
- When user launch the app for the SecondCount time.
- Then a content dialog is shown with two buttons.
- When user click "no thanks" button.
- Then the content dialog will never show again.
![Feedback](https://raw.githubusercontent.com/EdiWang/UWP-RateMyApp/master/screenshots/screenshot3.png)

Original Rate My App Readme
------------

The Rate My App component is used to create prompts that appear at set intervals
and allow the user to provide feedback and rate the application in the Windows
Phone Store.

By default, when the application with Rate My App component is started for the
5th time, a dialog for reviewing the app is shown to the user. If the user
declines to review the app, she will be given the option to provide direct
feedback to the developer. On the 10th run of the app, if a review was not
already collected, the user will be prompted one more time to rate the app. The
interval of showing the dialogs, as well as the precise textual content of the
dialogs can be configured to better suit your needs.

This solution consists of Rate My App component and several demo applications
demonstrating how Rate My App component can be integrated to various kinds of
Windows Phone applications like XAML, Panorama, XAML/XNA, XAML/Direct3D apps.

This solution is hosted in GitHub:
https://github.com/Microsoft/rate-my-app

Rate My App component is also available through NuGet Package Manager. Search
NuGet repositories for "RateMyApp", install it on your application, and follow
the instructions in Rate My App Guide to easily integrate review and feedback
functionality to your app. 

Tested Device
------------
- Microsoft Surface Pro 3 (Windows 10 Pro v1511)
- Microsoft Lumia 950 XL (Windows 10 Mobile 14267)

Known Issues
------------
- App version is missing in Email content 