using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Guest_app.Common
{
    public class HelperClass
    {
        public static void msg(string message)
        {
            var dialog = new MessageDialog(message);
            dialog.ShowAsync();
        }
    }
}
