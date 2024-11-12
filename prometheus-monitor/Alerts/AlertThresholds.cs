using System;
using System.Collections.Generic;
using System.Text;

namespace prometheus_monitor.Alerts
{
    public class AlertThresholds
    {
        public int LoginFrequencyThreshold { get; set; }
        public int IPChangeThreshold { get; set; }
        public double AccessPatternDeviation { get; set; }
    }
}
