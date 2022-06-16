      //Insert Button Click
      private void InsertDataSQL_Click(object sender, EventArgs e)
        {

            int hr = Convert.ToInt32(nu_hour.Value);
            int mins = Convert.ToInt32(nu_min.Value);
            DateTime dt = DateTime.Today.AddHours(hr).AddMinutes(mins);
            string meetingtime = (dt.ToString("hh:mm"));

            meetingdate.Format = DateTimePickerFormat.Custom;
            meetingdate.CustomFormat = "yyyy-MM-dd";

           
            SqlConnection conn = new SqlConnection(connString);

            
            string sql_Query3 = "Insert into Visitor(FirstName, Surname, Mobile, Email, Meeting_date, Meeting_aim, Meeting_time, Staff_ID) values ('" + name_tb.Text + "','" + surname_tb.Text + "','" + mobile_tb.Text + "','" + email_tb.Text + "','" + meetingdate.Text + "','" + meetaim_btn.Text + "','" + meetingtime + "','" + TB_Staff_ID.Text + "')";

            
            SqlCommand cmd4 = new SqlCommand(sql_Query3, conn);

            //Open connection
            conn.Open();

            cmd4.ExecuteNonQuery();

            MessageBox.Show("Record Saved/Inseted"); 
            //Close connection
            conn.Close();

            
            ListBox_Data_Load();

        }
        
        //Delete 
        
        private void DeleteData_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(connString);

            string sql_Query = "Delete from Visitor where Visitor_ID = " + TB_Visitor_ID.Text;
       
            SqlCommand cmd5 = new SqlCommand(sql_Query, conn);

            conn.Open();

            cmd5.ExecuteNonQuery();

            MessageBox.Show("Record Deleted"); 
            
            conn.Close();

            ListBox_Data_Load(); 
        }
        
        //Update
        
        private void UpdateData_Click(object sender, EventArgs e)
        {

            int hr = Convert.ToInt32(nu_hour.Value);
            int mins = Convert.ToInt32(nu_min.Value);
            DateTime dt = DateTime.Today.AddHours(hr).AddMinutes(mins);
            string meetingtime = (dt.ToString("hh:mm"));

            SqlConnection conn = new SqlConnection(connString);

            
            string sql_Query4 = "Update Visitor set FirstName = '" + name_tb.Text + "', Surname = '" + surname_tb.Text + "', Mobile ='" + mobile_tb.Text + "', Email ='" + email_tb.Text + "', Meeting_date ='" + meetingdate.Text + "', Meeting_time = '" + meetingtime + "', Staff_ID =" + TB_Staff_ID.Text  + "Where Visitor_ID =" + TB_Visitor_ID.Text;

            MessageBox.Show(sql_Query4);
           
            SqlCommand cmd5 = new SqlCommand(sql_Query4, conn);

            
            conn.Open();

            cmd5.ExecuteNonQuery();

            MessageBox.Show("Record Updated"); 
            
            conn.Close();

            ListBox_Data_Load(); 

        }
        
        //Edit
        private void LB_inforamtion_MouseClick(object sender, MouseEventArgs e)
        {
            int hr = Convert.ToInt32(nu_hour.Value);
            int mins = Convert.ToInt32(nu_min.Value);
            DateTime dt = DateTime.Today.AddHours(hr).AddMinutes(mins);
            string meetingtime = (dt.ToString("hh:mm"));

            meetingdate.Format = DateTimePickerFormat.Custom;
            meetingdate.CustomFormat = "yyyy-MM-dd";

            var selectedValue = information_lb.SelectedItem;
            if (selectedValue != null)
            {
                MessageBox.Show(selectedValue.ToString());
            }
            string VisitorData = information_lb.SelectedItem.ToString();
            string[] Field_Data = VisitorData.Split(' ');
            Visitor_ID = int.Parse(Field_Data[0]);

            // Creating instance of SqlConnection
            SqlConnection conn = new SqlConnection(connString);

            // set the sql command ( Statement )
            string sql_Query = "select Visitor.Visitor_ID, Visitor.FirstName, Visitor.Surname, Visitor.Mobile, Visitor.Email, Visitor.Meeting_date, Visitor.Meeting_aim, Visitor.Meeting_time, Staff.Meeting_with , Staff.Staff_ID From Visitor, Staff Where Visitor.Staff_ID = Staff.Staff_ID AND Visitor_ID = " + Visitor_ID;

            SqlCommand cmd = new SqlCommand(sql_Query, conn);

            //Open connection
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                TB_Visitor_ID.Text = reader["Visitor_ID"].ToString();
                name_tb.Text = reader["FirstName"].ToString();
                surname_tb.Text = reader["Surname"].ToString();
                mobile_tb.Text = reader["Mobile"].ToString();
                email_tb.Text = reader["Email"].ToString();
                meetingdate.Text = reader["Meeting_date"].ToString();
                metting_aim.Text = reader["Meeting_aim"].ToString();
                meetingtime = reader["Meeting_time"].ToString();
                meeting_with.Text = reader["Meeting_with"].ToString();
                TB_Staff_ID.Text = reader["Staff_ID"].ToString();
            }

            //Close Database reader
            reader.Close();

            //Close connection
            conn.Close();

        }
