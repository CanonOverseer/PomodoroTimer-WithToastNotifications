using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;

namespace PomodoroService
{
    public static class PomodoroToasts
    {
        public static ToastContentBuilder GetToastBuilder(string mainText, string subText, Uri logoUri)
        {
            var tcb = new ToastContentBuilder()
                .AddAppLogoOverride(logoUri, ToastGenericAppLogoCrop.Circle)
                .AddText(mainText)
                .AddText(subText);

            return tcb;
        }
    }
}
