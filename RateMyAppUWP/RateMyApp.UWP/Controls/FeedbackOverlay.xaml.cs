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
using DoubleAnimation = Windows.UI.Xaml.Media.Animation.DoubleAnimation;
using Colors = Windows.UI.Colors;

namespace RateMyApp.UWP.Controls
{
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

        public FeedbackOverlay()
        {
            this.InitializeComponent();
        }
    }
}
