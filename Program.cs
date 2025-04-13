namespace Project3__AirlineReservationConsoleSystem
{
    internal class Program
    {
        static int Max_Flight = 3;
        static int FlightCounter = 0;
        static string[] flightCode_A = new string[Max_Flight];
        static string[] fromCity_A = new string[Max_Flight];
        static string[] toCity_A = new string[Max_Flight];
        static DateTime[] departureTime_A = new DateTime[Max_Flight];
        static int[] duration_A = new int[Max_Flight];
        static int[] SeatsNum_A = new int[Max_Flight];
        static int[] SeatReserved_A = new int[Max_Flight];

        static bool isValid = false;

        static string[] PassengerName_A = new string[200];
        static string[] BookingFlightCode_A = new string[200];
        static int count_seat = 0;
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to Airline Reservation System");
        }
        public static int ShowMainMenu()
        {
            int option = 0;
            do
            {
                //to clear screen
                Console.Clear();
                //the menu list
                Console.WriteLine("Airline Reservation System");
                Console.WriteLine("1.Add flights");
                Console.WriteLine("2.Disaplay All Flights.");
                Console.WriteLine("3. Find Flight By Code");
                Console.WriteLine("4. Update Flight Departure");
                Console.WriteLine("5. Cancel Flight Booking");
                Console.WriteLine("6. Book Flight");
                Console.WriteLine("7. Validate Flight Code");
                Console.WriteLine("8. Generate Booking ID");
                Console.WriteLine("9. Display Flight Details");
                Console.WriteLine("10.Search Bookings By Destination");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter the option: ");
                string input = Console.ReadLine();
                try
                {
                    option = int.Parse(input);// Attempt to parse the input
                    isValid = true; // If parsing is successful, set isValid to true
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 5.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(); // Wait for user to acknowledge the message
                    isValid = false; // Keep isValid false to repeat the loop
                }
            } while (!isValid);// Continue looping until valid input is received
            return option;
        }
        public static void ExitApplication()
        {
            Console.WriteLine("Thanks! Have Happy Day!");
        }
        // 4. Add Flight information method
        public static void AddFlight(string flightCode, string fromCity, string toCity, DateTime departureTime, int duration, int SeatsNum)
        {
            // If all validations pass, save the data
            flightCode_A[FlightCounter] = flightCode;
            fromCity_A[FlightCounter] = fromCity;
            toCity_A[FlightCounter] = toCity;
            departureTime_A[FlightCounter] = departureTime;
            duration_A[FlightCounter] = duration;
            SeatsNum_A[FlightCounter] = SeatsNum;

        }
        public static void DisplayAllFlights()
        {
            Console.WriteLine("All Available Flight Information ");
            // Loop through all flights up to the current number of valiable flight
            for (int i = 0; i < FlightCounter; i++)
            {
                //check if flight is avilable
                if (SeatReserved_A[i] < SeatsNum_A[i])
                {
                    // Display all information of avilable flight
                    Console.WriteLine($"Avilable Flight {FlightCounter}: ");
                    Console.WriteLine($"Flight Code: {flightCode_A[i]}");
                    Console.WriteLine($"From City: {fromCity_A[i]}");
                    Console.WriteLine($"To City: {toCity_A[i]}");
                    Console.WriteLine($"Departure Time: {departureTime_A[i]}");
                    Console.WriteLine($"Duration : {duration_A[i]} hours");
                    Console.WriteLine($"Seats Number: {SeatsNum_A[i]} Seats"); // Number of Avilabe seats on specific flight
                    Console.WriteLine($"Reserved Seats Number: {SeatReserved_A[i]} Seats"); // display how many number of seat are reserve in th flight
                    Console.WriteLine($"Remaining  Seats Number: {SeatsNum_A[i] - SeatReserved_A[i]} Seats"); // display how many of seats are remaine
                    Console.WriteLine("-------------------------------------------------------------------------");
                }
            }

            Console.WriteLine("All Not Avilable Flight Information ");
            // Loop through all flights up to the current number of not valiable flight
            for (int i = 0; i < FlightCounter; i++)
            {
                //check if flight is is not avilable
                if (SeatReserved_A[i] == SeatsNum_A[i])
                {
                    // display the information of not avilable flight
                    Console.WriteLine($"Avilable Flight : ");
                    Console.WriteLine($"Flight Code: {flightCode_A[i]}");
                    Console.WriteLine($"From City: {fromCity_A[i]}");
                    Console.WriteLine($"To City: {toCity_A[i]}");
                    Console.WriteLine($"Departure Time: {departureTime_A[i]}");
                    Console.WriteLine($"Duration : {duration_A[i]} hours");
                    Console.WriteLine($"Seats Number: {SeatsNum_A[i]} Seats"); 
                    Console.WriteLine($"Reserved Seats Number: {SeatReserved_A[i]} Seats"); 
                    Console.WriteLine($"Remaining  Seats Number: {SeatsNum_A[i] - SeatReserved_A[i]} Seats"); 
                    
                }
            }
            
        }




        public static void StartSystem()
        {
            DisplayWelcomeMessage();//call function

            Console.ReadLine(); //to allow the user to press ANY KEy before conting
            while (true)
            {
                int option = ShowMainMenu();

                 
                string flight_Code = null;
                string from_City = null;
                string to_City = null;
                DateTime departure_Time;
                int duration_1 = 0;
                int Seats_Num = 0;
                char ChoiceChar = 'y';
                bool AddMore = true;
                int traies = 0;

                
                switch (option)
                {
                    case 1:
                        while (AddMore && FlightCounter < Max_Flight)
                            Console.WriteLine($"Enter fliht {FlightCounter} information");
                        do
                            {
                            Console.WriteLine("Enter Flight code:");
                            flight_Code = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(flight_Code))
                            {
                                Console.WriteLine("Flight code cannot be empty.");
                                isValid = false;
                                traies++;
                            }
                            else
                            {
                                isValid = true;
                                traies = 0;
                            }// (Optional) Check if flight code already exists
                            for (int i = 0; i < FlightCounter; i++)
                            {
                                if (flightCode_A[i] == flight_Code)
                                {
                                    Console.WriteLine("A flight with this code already exists.");
                                    isValid = false;
                                    traies++;
                                }
                                else
                                {
                                    isValid = true;
                                    traies = 0;
                                }

                            }

                            if (traies > 3)
                            {
                                Console.WriteLine("Failed to provide a valid flight code after 3 tries.");
                                return;
                            }

                        } while (!isValid && traies <= 3); // if the input is not vlidate repet ask the user 
                        //city input
                        Console.WriteLine("Enter From City :");
                        from_City = Console.ReadLine();
                        //if
                        break;

                    case 2:
                        DisplayAllFlights();
                        Console.WriteLine("press any key to return to the menu");
                        Console.ReadKey();
                        break;
                    //case 3:
                    //    Console.WriteLine("Enter the code of Flight : ");
                    //    string code = Console.ReadLine();
                    //    FindFlightByCode(code);
                    //    Console.WriteLine("\nPress any key to return to the menu...");
                    //    Console.ReadKey();
                    //    break;

                }

                        

                }
            }
        

        static void Main(string[] args)
        {
            StartSystem();
        }
    }
}
