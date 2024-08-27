namespace ejemploListView
{
    public partial class MainPage : ContentPage
    {   

        public MainPage()
        {
            InitializeComponent();

            /*
            //Data lista de strings
            List<string> contacts = new List<string>()
            {
                "Hanzeel",
                "Santi",
                "Fernando",
            };
            */

            //Data lista de Contact
            List<Contact> contacts = new List<Contact>
            {
                new() {Name="Hanzeel", Email="email.com"},
                new() {Name="Santi", Email="email.com.mx"},
                new() {Name="Angel", Email="email.com.mx"},

            };

            //Decirle a listView que data mostrar
            listContacts.ItemsSource = contacts;
        }
    }
    
    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
} 
