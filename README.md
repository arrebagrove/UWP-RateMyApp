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
 

License
-------

See the license text file delivered with this project:
https://github.com/Microsoft/rate-my-app/blob/master/License.txt