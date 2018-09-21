using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Ado.Net_App
{
    internal enum EPages
    {
        [Description("просмотр событий")]
        viewingEvents,
        [Description("просмотр статистики")]
        viewStatistics
    }
    internal enum ESort
    {
        day,month,week
    }
    internal enum ECount
    {
        enter,workTime
    }
   
}
