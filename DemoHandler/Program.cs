// See https://aka.ms/new-console-template for more information


using DemoHandler;
using MessagePasser;

var aggreagator = new EventAggregator();

var Handler1 = new Handler(aggreagator);

Handler1.SendMessage("Hello");

Console.ReadLine();

