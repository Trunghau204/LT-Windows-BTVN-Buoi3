using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsListView1
{
    public partial class FrmListView : Form
    {
        public FrmListView()
        {
            InitializeComponent();
        }

        private void btnAddName_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ TextBox
            string lastName = txtLastName.Text;
            string firstName = txtFirstName.Text;
            string phone = txtPhone.Text;

            // Kiểm tra dữ liệu rỗng
            if (string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm dữ liệu vào ListView
            ListViewItem item = new ListViewItem(new string[] { lastName, firstName, phone });
            listView1.Items.Add(item);

            // Xóa nội dung trong TextBox
            txtLastName.Clear();
            txtFirstName.Clear();
            txtPhone.Clear();
        }

        private void btnEditName_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn dòng nào chưa
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hàng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy hàng được chọn
            ListViewItem selectedItem = listView1.SelectedItems[0];

            // Hiển thị dữ liệu lên TextBox để sửa
            txtLastName.Text = selectedItem.SubItems[0].Text;
            txtFirstName.Text = selectedItem.SubItems[1].Text;
            txtPhone.Text = selectedItem.SubItems[2].Text;

            // Xóa hàng cũ (người dùng cần nhấn "Add Name" để lưu lại sửa đổi)
            listView1.Items.Remove(selectedItem);
        }

        private void btnDeleteName_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn dòng nào chưa
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xóa hàng được chọn
            listView1.Items.Remove(listView1.SelectedItems[0]);
        }
    }
}
