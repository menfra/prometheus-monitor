using System;
using System.Collections.Generic;
using System.Text;

namespace prometheus_monitor.Service
{
    public interface IPrometheusMonitor
    {
        void LogLogin(string userId, string ipAddress);
        bool DetectAnomalies(string userId);
    }
}
