using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShabatHost
{
    public class FormHandler
    {
        private DBContext _dbContext;
        private Queries _queries;
        private List<Category> categoriesForms;
        private int _index = 0;

        public FormHandler(DBContext dBContext)
        {
            _dbContext = dBContext;
            _queries = new Queries(_dbContext);
            categoriesForms = new List<Category>();
        }

        private void InitCategoriesForms(int id)
        {
            DataTable dt = _queries.GetCategories();
            foreach (DataRow dr in dt.Rows)
            {
                Category frm = new Category(_dbContext, dr["CategoryName"].ToString()!, id, this);
                categoriesForms.Add(frm);
            }
            return;
        }

        public void ShowFirstCategory(int id)
        {
            if (categoriesForms.Count == 0)
                InitCategoriesForms(id);
            ShowCategories();
        }

        public void ShowCategories()
        {
            categoriesForms[_index].Show();
        }

        public void Next()
        {
            categoriesForms[_index].Hide();
            _index = _index == categoriesForms.Count-1? 0: _index+1;
            ShowCategories();
        }

        public void Previous()
        {
            categoriesForms[_index].Hide();
            _index = _index == 0 ? categoriesForms.Count - 1 : _index - 1;
            ShowCategories();
        }

        private void CloseAllForms()
        {
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                Application.OpenForms[i]?.Hide();
            }
        }

        public void Show(string frm, DBContext dBContext)
        {

            CloseAllForms();

            Form myForm = frm switch
            {
            "Form1" => new Form1(dBContext, this),
            "HostForm" => new HostForm(dBContext),
            "GuestJoin" => new GuestJoin(dBContext, this),
            //"Category" => new Category(dBContext),
            _ => throw new ArgumentException("invalid form name ", nameof(frm))
            };
            myForm.Show();
        }
    }
}
