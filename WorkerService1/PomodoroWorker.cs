namespace PomodoroService
{
    public class PomodoroWorker : BackgroundService
    {
        private readonly ILogger<PomodoroWorker> _logger;

        public static TimeSpan BreakTimeSpan { get; set; } = TimeSpan.FromMinutes(5);
        public static TimeSpan WorkTimeSpan { get; set; } = TimeSpan.FromMinutes(25);

        private readonly Uri _logoUri =
            new Uri("file:///" + Path.GetFullPath(@"resources\pomodoro.png"), UriKind.Absolute);

        public PomodoroWorker(ILogger<PomodoroWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Work
                var workToastBuilder = PomodoroToasts.GetToastBuilder("Time to Work!",
                    $"Break time in {WorkTimeSpan.Minutes} Minutes ({DateTime.Now.Add(WorkTimeSpan).ToShortTimeString()})",
                    _logoUri);

                workToastBuilder.Show(workToast => { workToast.ExpirationTime = DateTimeOffset.Now.AddMinutes(5); });

                await Task.Delay(WorkTimeSpan, stoppingToken);

                // Break
                var breakToastBuilder = PomodoroToasts.GetToastBuilder("Rest Time",
                    $"Have a {BreakTimeSpan.Minutes} minute rest (Until {DateTime.Now.Add(BreakTimeSpan).ToShortTimeString()})",
                    _logoUri);

                breakToastBuilder.Show(breakToast => { breakToast.ExpirationTime = DateTimeOffset.Now.AddMinutes(5); });

                await Task.Delay(BreakTimeSpan, stoppingToken);
            }
        }
    }
}