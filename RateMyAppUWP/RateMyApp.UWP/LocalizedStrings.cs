using RateMyApp.UWP.Resources;

namespace RateMyApp.UWP
{
    /// <summary>
    /// Provides access to string resources.
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();

        public AppResources LocalizedResources => _localizedResources;
    }
}