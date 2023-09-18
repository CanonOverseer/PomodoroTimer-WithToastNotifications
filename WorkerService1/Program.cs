using PomodoroService;
using Spectre.Console;

Console.Title = "Pomodoro Timer";

var workTime = new TextPrompt<int>("How long between breaks? (in Minutes)")
    .DefaultValue(25)
    .Show(AnsiConsole.Console);

var breakTime = new TextPrompt<int>("How long of a break (in Minutes)")
    .DefaultValue(5)
    .Show(AnsiConsole.Console);

PomodoroWorker.BreakTimeSpan = TimeSpan.FromMinutes(breakTime);
PomodoroWorker.WorkTimeSpan = TimeSpan.FromMinutes(workTime);

AnsiConsole.Write("Beginning Timer.\n\n");

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<PomodoroWorker>();
    })
    .Build();

await host.RunAsync();
