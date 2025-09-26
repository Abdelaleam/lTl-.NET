using Day2_Task.Data;
using Day2_Task.Models;
using Day2_Task.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Day2_Task
{
    public partial class Form1 : Form
    {
        private readonly IRepository<Movie> _repository;
        private Movie? _selectedMovie;
        public Form1()
        {
            InitializeComponent();
            var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();
            var constr = config.GetSection("constr").Value;
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(constr).Options;
            var context = new AppDbContext(options);
            _repository = new Repository<Movie>(context);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_selectedMovie != null && ValidateInputs(out TimeSpan Duration))
            {
                _selectedMovie.Title = textBox1.Text;
                _selectedMovie.Duration = Duration;
                _selectedMovie.Genre = textBox3.Text;
                _repository.Update(_selectedMovie);
                _repository.Save();
                RefreshDataGrid();
                ClearInputs();
                MessageBox.Show("Movie updated successfully:)");
            }
        }

        private void RefreshDataGrid()
        {
            var list = _repository.GetAll();
            dataGridView1.DataSource = list;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Columns["MovieId"].Visible = false;
            dataGridView1.ClearSelection();
        }
        private void UpdateButtonState()
        {
            button1.Enabled = _selectedMovie == null;
            button2.Enabled = _selectedMovie != null;
            button3.Enabled = _selectedMovie != null;
            button4.Enabled = true;
            button5.Enabled = _selectedMovie != null;
        }
        private void ClearInputs()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            _selectedMovie = null;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var movieId = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            _selectedMovie = _repository.GetById(movieId);
            if (_selectedMovie != null)
            {
                textBox1.Text = _selectedMovie.Title;
                textBox2.Text = _selectedMovie.Genre;
                textBox3.Text = _selectedMovie.Duration.ToString();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
            UpdateButtonState();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0].DataBoundItem as Movie;
                if (row != null)
                {
                    _selectedMovie = row;
                    textBox1.Text = _selectedMovie.Title;
                    textBox2.Text = _selectedMovie.Duration.ToString();
                    textBox3.Text = _selectedMovie.Genre;

                }
            }
            else
            {
                _selectedMovie = null;
                ClearInputs();
            }
            UpdateButtonState();

        }
        private bool ValidateInputs(out TimeSpan Duration)
        {
            Duration = TimeSpan.Zero;
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Movie Title cannot be empty.");
                return false;
            }
            if (!TimeSpan.TryParse(textBox2.Text, out Duration))
            {
                MessageBox.Show("Please enter a valid duration format (hh:mm:ss).");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Movie Genre cannot be empty.");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateInputs(out TimeSpan Duration))
            {
                var movie = new Movie
                {
                    Title = textBox1.Text,
                    Duration = Duration,
                    Genre = textBox3.Text
                };
                _repository.Add(movie);
                _repository.Save();
                RefreshDataGrid();
                ClearInputs();
                MessageBox.Show("Movie added successfully:)");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_selectedMovie != null)
            {
                var confirmResult = MessageBox.Show("Are you sure to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    _repository.Delete(_selectedMovie);
                    _repository.Save();
                    RefreshDataGrid();
                    ClearInputs();
                    MessageBox.Show("Movie deleted successfully:)");
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearInputs();
            dataGridView1.ClearSelection();
            UpdateButtonState();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (_selectedMovie != null)
            {
               
            }
            using (var context = new AppDbContext())
            {
                var report = context.Screenings
                    .Where(s=>s.MovieId == _selectedMovie.MovieId)
                       .GroupJoin(
                           context.Tickets,
                           s => s.ScreeningId,
                           t => t.ScreeningId,
                           (s, tickets) => new
                           {
                               s.ScreeningId,
                               s.ScreeningTime,
                               s.AvailableSeats,
                               BookedSeats = tickets.Count(),
                               FreeSeats = s.AvailableSeats - tickets.Count()
                           }).ToList();
                Form2 form2 = new Form2(report);
                form2.Show();
            }
        }
    }
}

