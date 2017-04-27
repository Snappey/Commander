# Commander
Command Manager, easily create command structures for your .NET Applications with a simple syntax and interface.

## TODO
- Add Async Commands
- Implement Command Types

## Documentation

### CommandManager
Constructor, No Parameters.

```C# 
CommanderManager Manager = new CommanderManager()
```

### CommandManager.Add
Used to Add Commands, Returns Created (Command) Command.

```C#
Manager.Add((String) Name, (CommandType) Type, (Func<string, CommandType>) Callback, (Command) Parent)
````

### CommandManager.Search
Returns a (Command) Command with the given name.

```C#
Manager.Add((String) Name)
```

### CommandManager.Invoke
Used to execute a command with the given arguments, Returns a Bool whether command was successful or not.

```C#
Manager.Invoke((String) CommandName, (String) Arguments)
```

#### CommandManager.List
Lists all commads at the current level, Returns a String

```C#
Manager.List()
```

## Example
And if the above didnt make any sense, here is an example with all currently implemented features.

```C#
using System;
using Commander;
using Commander.Data;

namespace Commander_Test_App
{
    class Program
    {
        private static CommandManager manager;

        static void Main(string[] args)
        {
            manager = new CommandManager();
            var echo = manager.Add("echo", CommandType.Command, delegate(string s)
            {
                Console.WriteLine("You did this: " + s);
                return CommandType.Command; // Other types are not implemented, so this is the only type
            });

            manager.Add("echo-option-1", CommandType.Command, delegate(string s) 
            {
                Console.WriteLine("Wow this is the second layer!");
                return CommandType.Command;
            }, echo);

            manager.Add("echo-option-2", CommandType.Command, delegate(string s)
            {
                Console.WriteLine("It happens!");
                return CommandType.Command;
            }, echo);

            manager.Add("echo-option-3", CommandType.Command, delegate(string s)
            {
                Console.WriteLine("We're in the 2nd layer!");
                return CommandType.Command;
            }, echo);


            var branch = manager.Add("branch", CommandType.Command, delegate(string s)
            {
                Console.WriteLine("Second Branch: " + s);
                return CommandType.Command;
            });

            manager.Add("branch-testing", CommandType.Command, delegate(string s)
            {
                Console.WriteLine("Second level of testing");
                return CommandType.Command;
            }, branch);


            manager.Invoke("echo", "This ran the `echo` command!"); // Invoke is used to activate a command 
            manager.Invoke("echo-option-1");
            var list = manager.List(); // List commands on the current active layer
            manager.Invoke("echo-option-3");
            manager.Invoke("back"); // `back` is a inbuilt command to go to the previous layer

            var res =  manager.Invoke("echo", "test"); // Returns whether the command was sucessfuly executed
            Console.WriteLine(res);

            Console.WriteLine(list);
            Console.ReadKey();
        }
    }
}

```
