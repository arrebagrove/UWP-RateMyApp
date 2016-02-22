using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System;
using System.Globalization;
using RateMyApp.UWP.Helpers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.ApplicationModel.Email;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Security.ExchangeActiveSyncProvisioning;
using RateMyApp.UWP.Resources;
using Colors = Windows.UI.Colors;

namespace RateMyApp.UWP.Controls
{
    /// <summary>
    /// The FeedbackOverlay is a user control which can be placed on the 
    /// first page in the app. The control must be the last element inside
    /// the layout grid and span all rows and columns so it is not obscured.
    /// </summary>
    public sealed partial class FeedbackOverlay : UserControl
    {
        // Use this from XAML to control rating TxtTitle
        #region RatingTitle Dependency Property

        public static readonly DependencyProperty RatingTitleProperty =
            DependencyProperty.Register(
                "RatingTitle", typeof(string), typeof(FeedbackOverlay),
                new PropertyMetadata(AppResources.RatingTitle, null));

        public static void SetRatingTitle(FeedbackOverlay element, string value)
        {
            element.SetValue(RatingTitleProperty, value);
        }

        public static string GetRatingTitle(FeedbackOverlay element)
        {
            return (string)element.GetValue(RatingTitleProperty);
        }

        #endregion

        // Use this from XAML to control rating TxtMessage 1
        #region RatingMessage1 Dependency Property

        public static readonly DependencyProperty RatingMessage1Property =
            DependencyProperty.Register(
                "RatingMessage1", typeof(string), typeof(FeedbackOverlay),
                new PropertyMetadata(AppResources.RatingMessage1, null));

        public static void SetRatingMessage1(FeedbackOverlay element, string value)
        {
            element.SetValue(RatingMessage1Property, value);
        }

        public static string GetRatingMessage1(FeedbackOverlay element)
        {
            return (string)element.GetValue(RatingMessage1Property);
        }

        #endregion

        // Use this from XAML to control rating TxtMessage 2
        #region RatingMessage2 Dependency Property

        public static readonly DependencyProperty RatingMessage2Property =
            DependencyProperty.Register(
                "RatingMessage2", typeof(string), typeof(FeedbackOverlay),
                new PropertyMetadata(AppResources.RatingMessage2, null));

        public static void SetRatingMessage2(FeedbackOverlay element, string value)
        {
            element.SetValue(RatingMessage2Property, value);
        }

        public static string GetRatingMessage2(FeedbackOverlay element)
        {
            return (string)element.GetValue(RatingMessage2Property);
        }

        #endregion

        // Use this from XAML to control rating button yes 
        #region RatingYes Dependency Property

        public static readonly DependencyProperty RatingYesProperty =
            DependencyProperty.Register(
                "RatingYes", typeof(string), typeof(FeedbackOverlay),
                new PropertyMetadata(AppResources.RatingYes, null));

        public static void SetRatingYes(FeedbackOverlay element, string value)
        {
            element.SetValue(RatingYesProperty, value);
        }

        public static string GetRatingYes(FeedbackOverlay element)
        {
            return (string)element.GetValue(RatingYesProperty);
        }

        #endregion

        // Use this from XAML to control rating button no 
        #region RatingNo Dependency Property

        public static readonly DependencyProperty RatingNoProperty =
            DependencyProperty.Register(
                "RatingNo", typeof(string), typeof(FeedbackOverlay),
                new PropertyMetadata(AppResources.RatingNo, null));

        public static void SetRatingNo(FeedbackOverlay element, string value)
        {
            element.SetValue(RatingNoProperty, value);
        }

        public static string GetRatingNo(FeedbackOverlay element)
        {
            return (string)element.GetValue(RatingNoProperty);
        }

        #endregion

        // Use this from XAML to control feedback TxtTitle
        #region FeedbackTitle Dependency Property

        public static readonly DependencyProperty FeedbackTitleProperty =
            DependencyProperty.Register(
                "FeedbackTitle", typeof(string), typeof(FeedbackOverlay),
                new PropertyMetadata(AppResources.FeedbackTitle, null));

        public static void SetFeedbackTitle(FeedbackOverlay element, string value)
        {
            element.SetValue(FeedbackTitleProperty, value);
        }

        public static string GetFeedbackTitle(FeedbackOverlay element)
        {
            return (string)element.GetValue(FeedbackTitleProperty);
        }

        #endregion

        // Use this from XAML to control feedback message1
        #region FeedbackMessage1 Dependency Property

        public static readonly DependencyProperty FeedbackMessage1Property =
            DependencyProperty.Register(
                "FeedbackMessage1", typeof(string), typeof(FeedbackOverlay),
                new PropertyMetadata(AppResources.FeedbackMessage1, null));

        public static void SetFeedbackMessage1(FeedbackOverlay element, string value)
        {
            element.SetValue(FeedbackMessage1Property, value);
        }

        public static string GetFeedbackMessage1(FeedbackOverlay element)
        {
            return (string)element.GetValue(FeedbackMessage1Property);
        }

        #endregion

        // Use this from XAML to control feedback button yes
        #region FeedbackYes Dependency Property

        public static readonly DependencyProperty FeedbackYesProperty =
            DependencyProperty.Register(
                "FeedbackYes", typeof(string), typeof(FeedbackOverlay),
                new PropertyMetadata(AppResources.FeedbackYes, null));

        public static void SetFeedbackYes(FeedbackOverlay element, string value)
        {
            element.SetValue(FeedbackYesProperty, value);
        }

        public static string GetFeedbackYes(FeedbackOverlay element)
        {
            return (string)element.GetValue(FeedbackYesProperty);
        }

        #endregion

        // Use this from XAML to control feedback button no 
        #region FeedbackNo Dependency Property

        public static readonly DependencyProperty FeedbackNoProperty =
            DependencyProperty.Register(
                "FeedbackNo", typeof(string), typeof(FeedbackOverlay),
                new PropertyMetadata(AppResources.FeedbackNo, null));

        public static void SetFeedbackNo(FeedbackOverlay element, string value)
        {
            element.SetValue(FeedbackNoProperty, value);
        }

        public static string GetFeedbackNo(FeedbackOverlay element)
        {
            return (string)element.GetValue(FeedbackNoProperty);
        }

        #endregion

        // Use this from XAML to control feedback to
        #region FeedbackTo Dependency Property

        public static readonly DependencyProperty FeedbackToProperty =
            DependencyProperty.Register(
                "FeedbackTo", typeof(string), typeof(FeedbackOverlay),
                new PropertyMetadata(null, null));

        public static void SetFeedbackTo(FeedbackOverlay element, string value)
        {
            element.SetValue(FeedbackToProperty, value);
        }

        public static string GetFeedbackTo(FeedbackOverlay element)
        {
            return (string)element.GetValue(FeedbackToProperty);
        }

        #endregion

        // Use this from XAML to control feedback subject
        #region FeedbackSubject Dependency Property

        public static readonly DependencyProperty FeedbackSubjectProperty =
            DependencyProperty.Register(
                "FeedbackSubject", typeof(string), typeof(FeedbackOverlay),
                new PropertyMetadata(AppResources.FeedbackSubject, null));

        public static void SetFeedbackSubject(FeedbackOverlay element, string value)
        {
            element.SetValue(FeedbackSubjectProperty, value);
        }

        public static string GetFeedbackSubject(FeedbackOverlay element)
        {
            return (string)element.GetValue(FeedbackSubjectProperty);
        }

        #endregion

        // Use this from XAML to control feedback body 
        #region FeedbackBody Dependency Property

        public static readonly DependencyProperty FeedbackBodyProperty =
            DependencyProperty.Register(
                "FeedbackBody", typeof(string), typeof(FeedbackOverlay),
                new PropertyMetadata(AppResources.FeedbackBody, null));

        public static void SetFeedbackBody(FeedbackOverlay element, string value)
        {
            element.SetValue(FeedbackBodyProperty, value);
        }

        public static string GetFeedbackBody(FeedbackOverlay element)
        {
            return (string)element.GetValue(FeedbackBodyProperty);
        }

        #endregion

        // Use this from XAML to control company name 
        #region CompanyName Dependency Property

        public static readonly DependencyProperty CompanyNameProperty =
            DependencyProperty.Register(
                "CompanyName", typeof(string), typeof(FeedbackOverlay),
                new PropertyMetadata(null, null));

        public static void SetCompanyName(FeedbackOverlay element, string value)
        {
            element.SetValue(CompanyNameProperty, value);
        }

        public static string GetCompanyName(FeedbackOverlay element)
        {
            return (string)element.GetValue(CompanyNameProperty);
        }

        #endregion

        // Use this from XAML to control application name 
        #region ApplicationName Dependency Property

        public static readonly DependencyProperty ApplicationNameProperty =
            DependencyProperty.Register(
                "ApplicationName", typeof(string), typeof(FeedbackOverlay),
                new PropertyMetadata(null, null));

        public static void SetApplicationName(FeedbackOverlay element, string value)
        {
            element.SetValue(ApplicationNameProperty, value);
        }

        public static string GetApplicationName(FeedbackOverlay element)
        {
            return (string)element.GetValue(ApplicationNameProperty);
        }

        #endregion

        // Use this from XAML to control first count
        #region FirstCount Dependency Property

        public static readonly DependencyProperty FirstCountProperty =
            DependencyProperty.Register("FirstCount", typeof(int), typeof(FeedbackOverlay), new PropertyMetadata(5, null));

        public static void SetFirstCount(FeedbackOverlay element, int value)
        {
            element.SetValue(FirstCountProperty, value);
        }

        public static int GetFirstCount(FeedbackOverlay element)
        {
            return (int)element.GetValue(FirstCountProperty);
        }

        #endregion

        // Use this from XAML to control second count
        #region SecondCount Dependency Property

        public static readonly DependencyProperty SecondCountProperty =
            DependencyProperty.Register("SecondCount", typeof(int), typeof(FeedbackOverlay), new PropertyMetadata(10, null));

        public static void SetSecondCount(FeedbackOverlay element, int value)
        {
            element.SetValue(SecondCountProperty, value);
        }

        public static int GetSecondCount(FeedbackOverlay element)
        {
            return (int)element.GetValue(SecondCountProperty);
        }

        #endregion

        // Use this from XAML to control whether to count only one launch per day
        #region CountDays Dependency Property

        public static readonly DependencyProperty CountDaysProperty =
            DependencyProperty.Register("CountDays", typeof(bool), typeof(FeedbackOverlay), new PropertyMetadata(false, null));

        public static void SetCountDays(FeedbackOverlay element, bool value)
        {
            element.SetValue(CountDaysProperty, value);
        }

        public static bool GetCountDays(FeedbackOverlay element)
        {
            return (bool)element.GetValue(CountDaysProperty);
        }

        #endregion

        // Use this from XAML to control overriding culture
        #region LanguageOverride Dependency Property

        public static readonly DependencyProperty LanguageOverrideProperty =
            DependencyProperty.Register("LanguageOverride", typeof(string), typeof(FeedbackOverlay), new PropertyMetadata(null, null));

        public static void SetLanguageOverride(FeedbackOverlay element, string value)
        {
            element.SetValue(LanguageOverrideProperty, value);
        }

        public static string GetLanguageOverride(FeedbackOverlay element)
        {
            return (string)element.GetValue(LanguageOverrideProperty);
        }

        #endregion

        // Title of the review/feedback notification
        private string Title
        {
            set
            {
                if (TxtTitle.Text != value)
                {
                    TxtTitle.Text = value;
                }
            }
        }

        // Message of the review/feedback notification
        private string Message
        {
            set
            {
                if (TxtMessage.Text != value)
                {
                    TxtMessage.Text = value;
                }
            }
        }

        // Button text for not acting upon review/feedback notification
        private string NoText
        {
            set
            {
                if (DigContent.SecondaryButtonText != value)
                {
                    DigContent.SecondaryButtonText = value;
                }
            }
        }

        // Button text for acting upon review/feedback notification
        private string YesText
        {
            set
            {
                if (DigContent.PrimaryButtonText != value)
                {
                    DigContent.PrimaryButtonText = value;
                }
            }
        }

        public FeedbackOverlay()
        {
            InitializeComponent();
            Loaded += FeedbackOverlay_Loaded;
        }

        /// <summary>
        /// Reset review and feedback funtionality. Makes notifications active
        /// again, for example, after a major application update.
        /// </summary>
        public void Reset()
        {
            FeedbackHelper.Default.Reset();
        }

        /// <summary>
        /// Reset review and feedback funtionality. Makes notifications active
        /// again, for example, after a major application update.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FeedbackOverlay_Loaded(object sender, RoutedEventArgs e)
        {
            // FeedbackTo property is mandatory and must be defined in xaml.
            if (GetFeedbackTo(this) == null || GetFeedbackTo(this).Length <= 0)
            {
                throw new ArgumentNullException(nameof(FeedbackToProperty), "Mandatory property not defined in FeedbackOverlay.");
            }

            // ApplicationName property is mandatory and must be defined in xaml.
            if (GetApplicationName(this) == null || GetApplicationName(this).Length <= 0)
            {
                throw new ArgumentNullException(nameof(ApplicationNameProperty), "Mandatory property not defined in FeedbackOverlay.");
            }

            // CompanyName property is mandatory and must be defined in xaml.
            if (GetCompanyName(this) == null || GetCompanyName(this).Length <= 0)
            {
                throw new ArgumentNullException(nameof(CompanyNameProperty), "Mandatory property not defined in FeedbackOverlay.");
            }

            // Application language override.
            if (GetLanguageOverride(this) != null)
            {
                OverrideLanguage();
            }

            // Set up FeedbackHelper with properties.
            FeedbackHelper.Default.FirstCount = GetFirstCount(this);
            FeedbackHelper.Default.SecondCount = GetSecondCount(this);
            FeedbackHelper.Default.CountDays = GetCountDays(this);

            // Inform FeedbackHelper of the creation of this control.
            FeedbackHelper.Default.Launching();

            // Check if review/feedback notification should be shown.
            if (FeedbackHelper.Default.State == FeedbackState.FirstReview)
            {
                SetupFirstMessage();
                ContentDialogResult result = await DigContent.ShowAsync();
                await HandleDialogResult(result);
            }
            else if (FeedbackHelper.Default.State == FeedbackState.SecondReview)
            {
                SetupSecondMessage();
                ContentDialogResult result = await DigContent.ShowAsync();
                await HandleDialogResult(result);
            }
            else
            {
                FeedbackHelper.Default.State = FeedbackState.Inactive;
            }
        }

        /// <summary>
        /// Set up first review TxtMessage shown after FirstCount launches.
        /// </summary>
        private void SetupFirstMessage()
        {
            Title = string.Format(GetRatingTitle(this), GetApplicationName());
            Message = GetRatingMessage1(this);
            YesText = GetRatingYes(this);
            NoText = GetRatingNo(this);
        }

        /// <summary>
        /// Set up second review TxtMessage shown after SecondCount launches.
        /// </summary>
        private void SetupSecondMessage()
        {
            Title = string.Format(GetRatingTitle(this), GetApplicationName());
            Message = GetRatingMessage2(this);
            YesText = GetRatingYes(this);
            NoText = GetRatingNo(this);
        }

        /// <summary>
        /// Set up feedback TxtMessage shown after first review TxtMessage.
        /// </summary>
        private void SetupFeedbackMessage()
        {
            Title = GetFeedbackTitle(this);
            Message = string.Format(GetFeedbackMessage1(this), GetApplicationName());
            YesText = GetFeedbackYes(this);
            NoText = GetFeedbackNo(this);
        }

        /// <summary>
        /// Launch market place review.
        /// </summary>
        private async Task OpenStoreReviewAsync()
        {
            await FeedbackHelper.Default.ReviewAsync();
        }

        /// <summary>
        /// Launch feedback email.
        /// </summary>
        private async Task LaunchFeedbackEmailAsync()
        {
            string version = string.Empty;
            var uri = new Uri("ms-appx:///AppxManifest.xml");
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(uri);
            using (var rastream = await file.OpenReadAsync())
            using (var appManifestStream = rastream.AsStreamForRead())
            {
                using (var reader = XmlReader.Create(appManifestStream, new XmlReaderSettings { IgnoreWhitespace = true, IgnoreComments = true }))
                {
                    var doc = XDocument.Load(reader);
                    var app = doc.Descendants("Identity").FirstOrDefault();
                    var versionAttribute = app?.Attribute("Version");
                    if (versionAttribute != null)
                    {
                        version = versionAttribute.Value;
                    }
                }
            }

            string company = GetCompanyName(this);
            if (company == null || company.Length <= 0)
            {
                company = "<Company>";
            }

            var easClientDeviceInformation = new EasClientDeviceInformation();

            // Body text including hardware, firmware and software info
            string body = string.Format(GetFeedbackBody(this),
                 easClientDeviceInformation.SystemProductName,
                 easClientDeviceInformation.SystemManufacturer,
                 easClientDeviceInformation.SystemFirmwareVersion,
                 easClientDeviceInformation.SystemHardwareVersion,
                 version,
                 company);

            // Send an Email with attachment
            EmailMessage email = new EmailMessage();
            email.To.Add(new EmailRecipient(GetFeedbackTo(this)));
            email.Subject = string.Format(GetFeedbackSubject(this), GetApplicationName());
            email.Body = body;
            await EmailManager.ShowComposeNewEmailAsync(email);
        }

        /// <summary>
        /// Override default assembly dependent localization for the control
        /// with another culture supported by the application and the library.
        /// </summary>
        private void OverrideLanguage()
        {
            CultureInfo originalCulture = CultureInfo.DefaultThreadCurrentUICulture;
            CultureInfo newCulture = new CultureInfo(GetLanguageOverride(this));

            CultureInfo.DefaultThreadCurrentCulture = newCulture;
            CultureInfo.DefaultThreadCurrentUICulture = newCulture;

            SetFeedbackBody(this, AppResources.FeedbackBody);
            SetFeedbackMessage1(this, string.Format(AppResources.FeedbackMessage1, GetApplicationName()));
            SetFeedbackNo(this, AppResources.FeedbackNo);
            SetFeedbackSubject(this, string.Format(AppResources.FeedbackSubject, GetApplicationName()));
            SetFeedbackTitle(this, AppResources.FeedbackTitle);
            SetFeedbackYes(this, AppResources.FeedbackYes);
            SetRatingMessage1(this, AppResources.RatingMessage1);
            SetRatingMessage2(this, AppResources.RatingMessage2);
            SetRatingNo(this, AppResources.RatingNo);
            SetRatingTitle(this, string.Format(AppResources.RatingTitle, GetApplicationName()));
            SetRatingYes(this, AppResources.RatingYes);

            CultureInfo.DefaultThreadCurrentCulture = originalCulture;
            CultureInfo.DefaultThreadCurrentUICulture = originalCulture;
        }

        /// <summary>
        /// Get application name.
        /// </summary>
        /// <returns>Name of the application.</returns>
        private string GetApplicationName()
        {
            string appName = GetApplicationName(this);

            // If application name has not been defined by the application,
            // extract it from the Application class.
            if (appName == null || appName.Length <= 0)
            {
                appName = Application.Current.ToString();
                if (appName.EndsWith(".App"))
                {
                    appName = appName.Remove(appName.LastIndexOf(".App"));
                }
            }

            return appName;
        }

        private async Task HandleDialogResult(ContentDialogResult result)
        {
            if (result == ContentDialogResult.Primary)
            {
                if (FeedbackHelper.Default.State == FeedbackState.FirstReview)
                {
                    await OpenStoreReviewAsync();
                }
                else if (FeedbackHelper.Default.State == FeedbackState.SecondReview)
                {
                    await OpenStoreReviewAsync();
                }
                else if (FeedbackHelper.Default.State == FeedbackState.Feedback)
                {
                    await LaunchFeedbackEmailAsync();
                }
                FeedbackHelper.Default.State = FeedbackState.Inactive;
            }

            if (result == ContentDialogResult.Secondary)
            {
                DigContent.Hide();
                // LaunchFeedbackEmailAsync TxtMessage is shown only after first review TxtMessage.
                if (FeedbackHelper.Default.State == FeedbackState.FirstReview)
                {
                    SetupFeedbackMessage();
                    FeedbackHelper.Default.State = FeedbackState.Feedback;
                    await DigContent.ShowAsync();
                }
                else
                {
                    FeedbackHelper.Default.State = FeedbackState.Inactive;
                }
            }
        }
    }
}
