# Prometheus-Monitor

**Prometheus-Monitor** is a lightweight C# .NET package for tracking unusual behavior on endpoints. It monitors key metrics such as login frequency, IP changes, and access patterns, and alerts the system when it detects deviations from baseline behavior. Prometheus-Monitor is ideal for enhancing endpoint security by identifying potential security threats through behavioral analysis.

## Key Features

- **Behavioral Monitoring**: Tracks user actions and key metrics to detect unusual behavior.
- **Alerts for Anomalies**: Notifies the system if deviations from normal patterns are detected.
- **Configurable Metrics**: Easily configure which metrics to track, such as login frequency, IP address changes, and access patterns.
- **Lightweight**: Minimal performance overhead, making it ideal for applications with real-time monitoring needs.

## Getting Started

### Installation

Install Prometheus-Monitor via NuGet Package Manager Console:

```bash
Install-Package Prometheus-Monitor
```

Or, add it to your .csproj file:
```xml
<PackageReference Include="Prometheus-Monitor" Version="1.0.0" />
```

#Setup and Configuration

To start monitoring, initialize Prometheus-Monitor in your application’s startup file (e.g., Startup.cs) and configure the metrics and alert thresholds you want to track.
```csharp
// Startup.cs
using PrometheusMonitor;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddPrometheusMonitor(options =>
        {
            options.TrackLoginFrequency = true;   // Enable tracking of login frequency
            options.TrackIPChanges = true;        // Enable tracking of IP address changes
            options.TrackAccessPatterns = true;   // Enable tracking of user access patterns
            options.AlertThresholds = new AlertThresholds
            {
                LoginFrequencyThreshold = 5,      // Example: Alert if login frequency exceeds 5 per minute
                IPChangeThreshold = 3,            // Example: Alert if IP changes more than 3 times in an hour
                AccessPatternDeviation = 0.2      // Example: 20% deviation from normal access pattern triggers an alert
            };
        });
    }
}
```

## Usage
Prometheus-Monitor can be integrated within your application to log user actions and detect suspicious behavior automatically.

## Example: Tracking Login Frequency and Detecting Anomalies
In this example, Prometheus-Monitor tracks login frequency, IP changes, and access patterns. If any metric deviates from its baseline, the system can log the incident or take action as configured.
```csharp
using PrometheusMonitor;

public class UserActivityService
{
    private readonly IPrometheusMonitor _prometheusMonitor;

    public UserActivityService(IPrometheusMonitor prometheusMonitor)
    {
        _prometheusMonitor = prometheusMonitor;
    }

    public void TrackLogin(string userId, string ipAddress)
    {
        _prometheusMonitor.LogLogin(userId, ipAddress);

        if (_prometheusMonitor.DetectAnomalies(userId))
        {
            // Handle detected anomaly, such as alerting or logging the incident
            Console.WriteLine("Unusual behavior detected for user: " + userId);
        }
    }
}
```
## Example Scenarios
1. Login Frequency Monitoring: Alerts the system if a user logs in unusually often within a short time, which might indicate a brute-force attempt.
2. IP Address Change Tracking: Flags accounts with frequent IP changes, which could suggest account-sharing or potential hijacking.
3. Access Pattern Analysis: Detects significant deviations from typical user access patterns, such as unusual file access or directory browsing.

## Contributing
We welcome contributions! Please open an issue or submit a pull request if you have suggestions or improvements.

## License
This project is licensed under the MIT License - see the LICENSE file for details.

## Contact
For questions or feedback, please contact [menfra@menfra.de].



