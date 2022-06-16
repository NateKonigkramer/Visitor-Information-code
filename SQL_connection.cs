public partial class Form1 : Form
    {
        //connection string to connect to database
        string connString = @"Data Source = T2152\SQLEXPRESS;
                        Initial Catalog = Stud_Database; 
                        Integrated Security = True; 
                        Connect Timeout = 30; 
                        Encrypt=False;
                        TrustServerCertificate=False;
                        ApplicationIntent=ReadWrite;
                        MultiSubnetFailover=False";
       
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Creating instance of SqlConnection 
            SqlConnection conn = new SqlConnection(connString);
            // set the sql command ( Statement ) 
            string sql_Query = "select Student_Info.Name, Student_Info.Mobile,Student_Info.Email, Course_Details.Course_Name From Student_Info, Course_Details Where Student_Info.Course_ID = Course_Details.Course_ID";
            // Creating instance of SqlCommand  and set the connection and query to instance of SqlCommand
            SqlCommand cmd = new SqlCommand(sql_Query, conn);   
            cmd.Parameters.Clear();
            //Open connection
            conn.Open();
            // Creating instance of SqlDataReader 
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //populate data in Listbox from Reader
                LB_Student.Items.Add((reader["Name"] + " -" + reader["Mobile"] + " " + reader["Email"] + " (" + reader["Course_Name"] + ")"));
            }
            //Close Database reader
            reader.Close();
            //Close connection
            conn.Close();

        }
    }
