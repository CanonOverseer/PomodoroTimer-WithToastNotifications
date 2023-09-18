using PomodoroService;
using Spectre.Console;

var prompt = new TextPrompt<int>("How long of a break (in Minutes)")
    .DefaultValue(5);

var breakTime = prompt.Show(AnsiConsole.Console);

prompt = new TextPrompt<int>("How long should you work (in Minutes)")
    .DefaultValue(25);

var workTime = prompt.Show(AnsiConsole.Console);

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
