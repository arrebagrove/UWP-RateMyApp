using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows;
using RateMyApp.UWP.Helpers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.ApplicationModel.Email;
using System.IO;
using Windows.Storage;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.ApplicationModel.Resources;
using RateMyApp.UWP.Resources;
using DoubleAnimation = Windows.UI.Xaml.Media.Animation.DoubleAnimation;
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
        public static readonly DependencyProperty VisibilityForDesignProperty =
            DependencyProperty.Register("VisibilityForDesign", typeof(Visibility), typeof(FeedbackOverlay), new PropertyMetadata(Visibility.Collapsed, null));

        public static void SetVisibilityForDesign(FeedbackOverlay element, Visibility value)
        {
            element.SetValue(VisibilityForDesignProperty, value);
        }

        public static Visibility GetVisibilityForDesign(FeedbackOverlay element)
        {
            return (Visibility)element.GetValue(VisibilityForDesignProperty);
        }

        // Using a DependencyProperty as the backing store for Background.  This enables animation, styling, binding, etc...
        #region Background Dependency Property
        public new Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }

        public new static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background", typeof(Brush), typeof(FeedbackOverlay), new PropertyMetadata(new SolidColorBrush(Colors.Black)));
        #endregion

        // Using a DependencyProperty as the backing store for Foreground.  This enables animation, styling, binding, etc...
        #region Foreground Dependency Property
        public new Brush Foreground
        {
            get { return (Brush)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }

        public new static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.Register("Foreground", typeof(Brush), typeof(FeedbackOverlay), new PropertyMetadata(new SolidColorBrush(Colors.White)));
        #endregion

        // Use this from XAML to control whether animation is on or off
        #region EnableAnimation Dependency Property

        public static readonly DependencyProperty EnableAnimationProperty =
            DependencyProperty.Register("EnableAnimation", typeof(bool), typeof(FeedbackOverlay), new PropertyMetadata(true, null));

        public static void SetEnableAnimation(FeedbackOverlay element, bool value)
        {
            element.SetValue(EnableAnimationProperty, value);
        }

        public static bool GetEnableAnimation(FeedbackOverlay element)
        {
            return (bool)element.GetValue(EnableAnimationProperty);
        }

        #endregion

        // Use this from XAML to control animation duration
        #region AnimationDuration Dependency Property

        public static readonly DependencyProperty AnimationDurationProperty =
          DependencyProperty.Register("AnimationDuration", typeof(TimeSpan), typeof(FeedbackOverlay), new PropertyMetadata(new TimeSpan(0, 0, 0, 0, 500), null));

        public static void SetAnimationDuration(FeedbackOverlay element, TimeSpan value)
        {
            element.SetValue(AnimationDurationProperty, value);
        }

        public static TimeSpan GetAnimationDuration(FeedbackOverlay element)
        {
            return (TimeSpan)element.GetValue(AnimationDurationProperty);
        }

        #endregion


        // Use this for MVVM binding IsVisible
        #region IsVisible Dependency Property

        public static readonly DependencyProperty IsVisibleProperty =
            DependencyProperty.Register("IsVisible", typeof(bool), typeof(FeedbackOverlay), new PropertyMetadata(false, null));

        public static void SetIsVisible(FeedbackOverlay element, bool value)
        {
            element.SetValue(IsVisibleProperty, value);
        }

        public static bool GetIsVisible(FeedbackOverlay element)
        {
            return (bool)element.GetValue(IsVisibleProperty);
        }

        #endregion

        // Use this for MVVM binding IsNotVisible
        #region IsNotVisible Dependency Property

        public static readonly DependencyProperty IsNotVisibleProperty =
            DependencyProperty.Register(
                "IsNotVisible", typeof(bool), typeof(FeedbackOverlay),
                new PropertyMetadata(true, null));

        public static void SetIsNotVisible(FeedbackOverlay element, bool value)
        {
            element.SetValue(IsNotVisibleProperty, value);
        }

        public static bool GetIsNotVisible(FeedbackOverlay element)
        {
            return (bool)element.GetValue(IsNotVisibleProperty);
        }

        #endregion

        // Use this from XAML to control rating title
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

        // Use this from XAML to control rating message 1
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

        // Use this from XAML to control rating message 2
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

        // Use this from XAML to control feedback title
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

        public FeedbackOverlay()
        {
            this.InitializeComponent();
        }
    }
}
