using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateMyApp.UWP
{
    public class ResHelper
    {
        public static string GetResource(string key)
        {
            return Windows.ApplicationModel.Resources.Core.ResourceManager.Current.MainResourceMap.GetValue($"RateMyApp.UWP/Resources/{key}").ValueAsString;
        }
    }
}
