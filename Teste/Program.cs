// See https://aka.ms/new-console-template for more information
using ProductExtrator.Robo;

Console.WriteLine("Hello, World!");

CoopRobot robot = new CoopRobot();
robot.Initialize();
robot.Execute();


Console.WriteLine("Fim da execução");
