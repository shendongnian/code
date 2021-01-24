    public class CommandLine
    {
        // returns true if parse was successful and you can proceed. Returns false if you can terminate
        public static bool ApplyCommandLineArguments(string[] args, Config config)
        {
            CommandLineApplication cla = new CommandLineApplication(false);
            CommandOption option1 = cla.Option(
                "-o | --option1",
                "Set this option to specify option1",
                CommandOptionType.SingleValue
            );
            cla.HelpOption("-? | -h | --help");
            cla.OnExecute(() =>
            {
                if (option1.HasValue()) {
                    config.Option1 = option1.Value();
                }
                // non-zero value
                return 1;
            });
            try {
                int result = cla.Execute(args);
                // check result
                return result > 0;
            }
            catch (CommandParsingException ex) {
                Console.WriteLine(ex.Message);
                cla.ShowHelp();
                return false;
            }
        }
    }
    public static void Main(string[] args)
        {
            Config config = new Config();
            if (!CommandLine.ApplyCommandLineArguments(args, config)) {
                return;
            }
            // I want to exit here if user specified the help option anywhere on the command line.
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
