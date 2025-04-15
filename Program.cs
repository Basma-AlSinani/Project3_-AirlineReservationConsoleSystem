class AirlineReservationSystem
{
    // Max limits
    const int MaxFlights = 10;
    const int MaxBookings = 20;

    // Flight data
    static string[] flightCodes = new string[MaxFlights];
    static string[] fromCities = new string[MaxFlights];
    static string[] toCities = new string[MaxFlights];
    static DateTime[] departureTimes = new DateTime[MaxFlights];
    static int[] durations = new int[MaxFlights];
    static int[] fare = new int[MaxFlights];
    static int flightCount = 0;


    // Booking data
    static string[] bookingIDs = new string[MaxBookings];
    static string[] passengerNames = new string[MaxBookings];
    static string[] bookedFlightCodes = new string[MaxBookings];

    static int bookingCount = 0;


    //Welcome Message
    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the Airline Reservation System!");

    }
    //Main Menu
    static int ShowMainMenu()
    {

        Console.WriteLine("Main Menu");

        Console.WriteLine("1. Book a Flight");
        Console.WriteLine("2. Cancel a Booking");
        Console.WriteLine("3. View All Flights");
        Console.WriteLine("4. View Flight Details (by flight code)");
        Console.WriteLine("5. Search Bookings by Destination");
        Console.WriteLine("6. add flight");
        Console.WriteLine("7. Update Flight Departure");

        Console.WriteLine("8. Exit");
        Console.Write("Select an option (1-8): ");
        int input = int.Parse(Console.ReadLine());
        Console.Clear();

        return input;
    }
    //Exit Application
    static void ExitApplication()
    {
        Console.WriteLine("Thank you for using the Airline Reservation System. Goodbye!");
        return;
    }
    //Flight add
    static void AddFlight(string flightCode, string fromCity, string toCity, DateTime departureTime, int duration, int price)
    {
        if (flightCount < MaxFlights)
        {
            flightCodes[flightCount] = flightCode;
            fromCities[flightCount] = fromCity;
            toCities[flightCount] = toCity;
            departureTimes[flightCount] = departureTime;
            durations[flightCount] = duration;
            fare[flightCount] = price;
            flightCount++;
        }
        else
        {
            Console.WriteLine("Flight limit reached. Cannot add more flights.");
        }
    }

    // Flight Display 
    static void DisplayAllFlights()
    {

        for (int i = 0; i < flightCount; i++)
        {
            Console.WriteLine("flight code : " + flightCodes[i]);
            Console.WriteLine("From: " + fromCities[i]);
            Console.WriteLine("To: " + toCities[i]);
            Console.WriteLine("Departure: " + departureTimes[i]);
            Console.WriteLine("Duration: " + durations[i] + " hours");
            Console.WriteLine("Price: $" + fare[i]);
        }
    }
    //Flight Search
    static bool FindFlightByCode(string code)
    {
        for (int i = 0; i < flightCount; i++)
        {
            if (flightCodes[i] == code)
            {
                Console.WriteLine("Flight found: " + flightCodes[i]);
                Console.WriteLine("From: " + fromCities[i]);
                Console.WriteLine("To: " + toCities[i]);
                Console.WriteLine("Departure: " + departureTimes[i]);
                Console.WriteLine("Duration: " + durations[i] + " hours");
                Console.WriteLine("Price: $" + fare[i]);
                return true;
            }
        }
        return false;
    }
    //Flight Departure Update 

    static void UpdateFlightDeparture(ref DateTime departure)
    {
        Console.WriteLine("Enter flight code to update: ");
        string flightCode = Console.ReadLine();
        for (int i = 0; i < flightCount; i++)
        {
            if (flightCodes[i] == flightCode)
            {
                departureTimes[i] = departure;
                Console.WriteLine("Flight departure updated successfully.");
                return;
            }
        }


    }
    // Booking Cancellation
    public static void CancelFlightBooking(out string canceld)
    {
        canceld = null;
        Console.Write("Enter passenger name to cancel booking: ");
        canceld = Console.ReadLine();
        bool found = false;

        for (int i = 0; i < bookingCount; i++)
        {
            if (passengerNames[i] == canceld)
            {
                if (ConfirmAction($"cancel booking for {passengerNames[i]}"))
                {

                    bookingIDs[i] = null;
                    passengerNames[i] = null;
                    bookedFlightCodes[i] = null;

                    found = true;
                    Console.WriteLine("Booking cancelled successfully.");
                }
                else
                {
                    Console.WriteLine("Booking cancellation aborted.");
                }
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("No booking found for the given passenger name.");
        }
    }

    // Flight Booking 
    static string BookFlight(string passengerName, string flightCode = "Default001")
    {
        if (bookingCount < MaxBookings) //check if booking limit is reached
        {
            bookingIDs[bookingCount] = GenerateBookingID(passengerName);
            passengerNames[bookingCount] = passengerName;
            bookedFlightCodes[bookingCount] = flightCode;
            bookingCount++;
            return bookingIDs[bookingCount - 1]; // return the booking ID of the newly booked flight
        }
        else
        {
            Console.WriteLine("Booking limit reached. Cannot book more flights.");
            return null;
        }


    }
    //Flight Code Validation 
    static bool ValidateFlightCode(string flightCode)
    {
        for (int i = 0; i < flightCount; i++)
        {
            if (flightCodes[i] == flightCode)
            {
                return true;
            }
        }
        return false;
    }
    // Booking ID Generation 

    static string GenerateBookingID(string passengerName)
    {

        string bookingID = "BID" + (bookingCount + 1).ToString();
        return bookingID;

    }
    //Flight Details 
    static void DisplayFlightDetails(string code)
    {
        for (int i = 0; i < flightCount; i++)
        {
            if (code == flightCodes[i])
            {
                Console.WriteLine("Flight Code: " + flightCodes[i]);
                Console.WriteLine("From: " + fromCities[i]);
                Console.WriteLine("To: " + toCities[i]);
                Console.WriteLine("Departure: " + departureTimes[i]);
                Console.WriteLine("Duration: " + durations[i] + " hours");
                Console.WriteLine("Fare: " + fare[i]);
                Console.WriteLine("Booking Details: ");
                Console.WriteLine("Booking ID: " + bookingIDs[i]);
                Console.WriteLine("Passenger Name: " + passengerNames[i]);
                Console.WriteLine("price: " + fare[i]);



            }
        }

    }
    // Search Bookings 

    static void SearchBookingsByDestination(string toCity)
    {
        for (int i = 0; i < flightCount; i++)
        {
            if (toCities[i] == toCity)
            {
                Console.WriteLine("Flight found: " + flightCodes[i]);
                Console.WriteLine("From: " + fromCities[i]);
                Console.WriteLine("To: " + toCities[i]);
                Console.WriteLine("Departure: " + departureTimes[i]);
                Console.WriteLine("Duration: " + durations[i] + " hours");
                Console.WriteLine("Price: $" + fare[i]);

            }
        }
    }

    //Fare Calculation
    static int CalculateFare(int basePrice, int numTickets)
    {
        return basePrice * numTickets;
    }

    static double CalculateFare(double basePrice, int numTickets)
    {

        return basePrice * numTickets;
    }

    static int CalculateFare(int basePrice, int numTickets, int discount)
    {



        int total = basePrice * numTickets;
        return total - (total * discount / 100);

    }

    //Confirm Action 
    static bool ConfirmAction(string action)

    {
        {
            Console.Write($"Are you sure you want to {action}? (y/n): ");
            string input = Console.ReadLine().ToLower();
            while (input != "y" && input != "n")
            {
                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                input = Console.ReadLine().ToLower();
            }
            return input == "y";
        }
    }
    // Main System Loop 
    static void StartSystem()
    {
        DisplayWelcomeMessage();

        while (true)
        {
            int choice = ShowMainMenu();
            switch (choice)
            {
                case 1: // Book a Flight
                    Console.Write("Enter passenger name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter flight code (optional): ");
                    string code = Console.ReadLine();
                    if (string.IsNullOrEmpty(code))
                    {
                        code = "Default001";
                    }
                    if (ValidateFlightCode(code)) // if the flight exists
                    {
                        string bookid = BookFlight(name, code);
                        Console.WriteLine($"Booking successful! Booking ID: {bookid}");

                        // Calculate fare
                        Console.Write("Enter number of tickets: ");
                        int numTickets = int.Parse(Console.ReadLine());
                        int basePrice = 0;
                        for (int i = 0; i < flightCount; i++)
                        {
                            if (flightCodes[i] == code)
                            {
                                basePrice = fare[i];
                                break;
                            }
                        }
                        Console.Write("Enter discount (0 if none): ");
                        int discount = int.Parse(Console.ReadLine());

                        int totalFare = CalculateFare(basePrice, numTickets, discount);
                        Console.WriteLine($"Total fare: ${totalFare}");
                    }


                    break;

                case 2:
                    Console.Write("Enter passenger name to cancel booking: ");
                    string passengerToCancel = null;
                    passengerToCancel = Console.ReadLine();
                    CancelFlightBooking(out passengerToCancel);
                    break;
                case 3:
                    DisplayAllFlights();
                    break;

                case 4:
                    Console.Write("Enter flight code: ");
                    string fcode = Console.ReadLine();
                    DisplayFlightDetails(fcode);
                    break;

                case 5:
                    Console.Write("Enter destination city: ");
                    string city = Console.ReadLine();
                    SearchBookingsByDestination(city);
                    break;


                case 6:
                    Console.WriteLine("Adding a new flight...");
                    Console.Write("Flight Code: ");
                    string flightCode = Console.ReadLine();
                    Console.Write("From City: ");
                    string fromCity = Console.ReadLine();
                    Console.Write("To City: ");
                    string toCity = Console.ReadLine();
                    Console.Write("Departure Time (yyyy-mm-dd hh:mm): ");
                    DateTime departureTime = DateTime.Parse(Console.ReadLine());
                    Console.Write("Duration (in hourse): ");
                    int duration = int.Parse(Console.ReadLine());
                    Console.Write("Price: ");
                    int price = int.Parse(Console.ReadLine());
                    AddFlight(flightCode, fromCity, toCity, departureTime, duration, price);

                    break;
                case 7:
                    Console.Write("Enter flight code to update: ");
                    string updateCode = Console.ReadLine();
                    Console.Write("Enter new departure time (yyyy-mm-dd hh:mm): ");
                    DateTime newDepartureTime = DateTime.Parse(Console.ReadLine());
                    UpdateFlightDeparture(ref newDepartureTime);
                    break;
                case 8:
                    ExitApplication();
                    return;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    //Main Entry Point 
    static void Main(string[] args)
    {
        StartSystem();
    }
}