using Day1_Task.Models;
using Day1_Task.Repositories;

namespace Day1_Task
{
    public partial class Form1 : Form
    {
        private IRepository<Product> _productRepository;
        private Product? _selectedProduct;
        public Form1()
        {
            InitializeComponent();
            _productRepository = new Repository<Product>(new AppDbContext());
            _selectedProduct = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
                var row = dataGridView1.SelectedRows[0].DataBoundItem as Product;
                if (row != null)
                {
                    _selectedProduct = row;
                    textBox1.Text = _selectedProduct.ProductName;
                    textBox2.Text = _selectedProduct.Price.ToString();
                    textBox3.Text = _selectedProduct.Stock.ToString();
                }
            }
            else
            {
                _selectedProduct = null;
                ClearInputs();
            }
            UpdateButtonState();

        }
        private void RefreshDataGrid()
        {
            var list = _productRepository.GetAll();
            dataGridView1.DataSource = list;
            dataGridView1.AutoGenerateColumns = true;
        if (dataGridView1.Columns["ProductId"] != null)
                dataGridView1.Columns["ProductId"].Visible = false;
        if (dataGridView1.Columns["SaleDetails"] != null)
                dataGridView1.Columns["SaleDetails"].Visible = false;
            dataGridView1.ClearSelection();
        }
        private void UpdateButtonState()
        {
            button1.Enabled = _selectedProduct == null;
            button2.Enabled = _selectedProduct != null;
            button3.Enabled = _selectedProduct != null;
            button4.Enabled = true;
        }
        private void ClearInputs()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            _selectedProduct = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateInputs(out string name, out decimal price, out int stock))
            {
                var prod = new Product
                {
                    ProductName = name,
                    Price = price,
                    Stock = stock
                };
                _productRepository.Add(prod);
                _productRepository.Save();
                RefreshDataGrid();
                ClearInputs();
                MessageBox.Show("Product added successfully:)");
            }

        }
        private bool ValidateInputs(out string name, out decimal price, out int stock)
        {
            name = textBox1.Text.Trim();
            bool isPriceValid = decimal.TryParse(textBox2.Text.Trim(), out price);
            bool isStockValid = int.TryParse(textBox3.Text.Trim(), out stock);
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Product name cannot be empty.");
                return false;
            }
            if (!isPriceValid || price < 0)
            {
                MessageBox.Show("Invalid price. Please enter a valid non-negative decimal number.");
                return false;
            }
            if (!isStockValid || stock < 0)
            {
                MessageBox.Show("Invalid stock. Please enter a valid non-negative integer.");
                return false;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_selectedProduct != null && ValidateInputs(out string name, out decimal price, out int stock))
            {
                _selectedProduct.ProductName = name;
                _selectedProduct.Price = price;
                _selectedProduct.Stock = stock;
                _productRepository.Update(_selectedProduct);
                _productRepository.Save();
                RefreshDataGrid();
                ClearInputs();
                MessageBox.Show("Product updated successfully.");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_selectedProduct != null)
            {
                var confirmResult = MessageBox.Show("Are you sure to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    _productRepository.Delete(_selectedProduct);
                    _productRepository.Save();
                    RefreshDataGrid();
                    ClearInputs();
                    MessageBox.Show("Product deleted successfully.");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearInputs();
            dataGridView1.ClearSelection();
            UpdateButtonState();
        }
    }
}
