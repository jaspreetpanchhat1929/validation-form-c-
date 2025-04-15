using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ValidationFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateFormControls();
        }

        private void CreateFormControls()
        {
            // Form properties
            this.Text = "User Registration Form";
            this.Size = new Size(400, 350);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Name Label
            Label nameLabel = new Label();
            nameLabel.Text = "Full Name:";
            nameLabel.Location = new Point(20, 20);
            nameLabel.Size = new Size(100, 20);
            this.Controls.Add(nameLabel);

            // Name TextBox
            TextBox nameTextBox = new TextBox();
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Location = new Point(120, 20);
            nameTextBox.Size = new Size(200, 20);
            this.Controls.Add(nameTextBox);

            // Email Label
            Label emailLabel = new Label();
            emailLabel.Text = "Email:";
            emailLabel.Location = new Point(20, 60);
            emailLabel.Size = new Size(100, 20);
            this.Controls.Add(emailLabel);

            // Email TextBox
            TextBox emailTextBox = new TextBox();
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Location = new Point(120, 60);
            emailTextBox.Size = new Size(200, 20);
            this.Controls.Add(emailTextBox);

            // Password Label
            Label passwordLabel = new Label();
            passwordLabel.Text = "Password:";
            passwordLabel.Location = new Point(20, 100);
            passwordLabel.Size = new Size(100, 20);
            this.Controls.Add(passwordLabel);

            // Password TextBox
            TextBox passwordTextBox = new TextBox();
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Location = new Point(120, 100);
            passwordTextBox.Size = new Size(200, 20);
            passwordTextBox.PasswordChar = '*';
            this.Controls.Add(passwordTextBox);

            // Age Label
            Label ageLabel = new Label();
            ageLabel.Text = "Age:";
            ageLabel.Location = new Point(20, 140);
            ageLabel.Size = new Size(100, 20);
            this.Controls.Add(ageLabel);

            // Age TextBox
            TextBox ageTextBox = new TextBox();
            ageTextBox.Name = "ageTextBox";
            ageTextBox.Location = new Point(120, 140);
            ageTextBox.Size = new Size(200, 20);
            this.Controls.Add(ageTextBox);

            // Validation Label (for error messages)
            Label validationLabel = new Label();
            validationLabel.Name = "validationLabel";
            validationLabel.Location = new Point(20, 180);
            validationLabel.Size = new Size(300, 40);
            validationLabel.ForeColor = Color.Red;
            this.Controls.Add(validationLabel);

            // Submit Button
            Button submitButton = new Button();
            submitButton.Text = "Submit";
            submitButton.Location = new Point(120, 230);
            submitButton.Size = new Size(100, 30);
            submitButton.Click += (sender, e) => ValidateForm(
                nameTextBox, emailTextBox, passwordTextBox, ageTextBox, validationLabel);
            this.Controls.Add(submitButton);
        }

        private void ValidateForm(TextBox nameTextBox, TextBox emailTextBox, 
                                TextBox passwordTextBox, TextBox ageTextBox, 
                                Label validationLabel)
        {
            validationLabel.Text = "";

            // Name validation
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                validationLabel.Text = "Name is required";
                return;
            }

            // Email validation
            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                validationLabel.Text = "Email is required";
                return;
            }

            if (!IsValidEmail(emailTextBox.Text))
            {
                validationLabel.Text = "Invalid email format";
                return;
            }

            // Password validation
            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                validationLabel.Text = "Password is required";
                return;
            }

            if (passwordTextBox.Text.Length < 8)
            {
                validationLabel.Text = "Password must be at least 8 characters";
                return;
            }

            // Age validation
            if (string.IsNullOrWhiteSpace(ageTextBox.Text))
            {
                validationLabel.Text = "Age is required";
                return;
            }

            if (!int.TryParse(ageTextBox.Text, out int age) || age < 18 || age > 120)
            {
                validationLabel.Text = "Age must be a number between 18 and 120";
                return;
            }

            // If all validations pass
            validationLabel.ForeColor = Color.Green;
            validationLabel.Text = "Form submitted successfully!";
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
