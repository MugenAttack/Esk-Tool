using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Esk;
namespace EskTool
{
    

    

    public partial class eskBoneEditor : Form
    {

        esk Skeleton;
        public eskBoneEditor()
        {
            InitializeComponent();
        }

        private void eskBoneEditor_Load(object sender, EventArgs e)
        {

        }

        public void loadEsk(string filepath)
        {
            

            

         }

        private void BoneBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void SaveSelected()
        {
            
        }

        private void m00_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(m00.Text, out Skeleton.Bones[BoneBox.SelectedIndex].transformData.m00).ToString();
            
        }

        private void m01_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(m01.Text, out Skeleton.Bones[BoneBox.SelectedIndex].transformData.m01).ToString();
            
        }

        private void m02_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(m02.Text, out Skeleton.Bones[BoneBox.SelectedIndex].transformData.m02).ToString();
            
        }

        private void m03_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(m03.Text, out Skeleton.Bones[BoneBox.SelectedIndex].transformData.m03).ToString();
            
        }

        private void m10_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(m10.Text, out Skeleton.Bones[BoneBox.SelectedIndex].transformData.m10).ToString();
            
        }

        private void m11_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(m11.Text, out Skeleton.Bones[BoneBox.SelectedIndex].transformData.m11).ToString();
            
        }

        private void m12_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(m12.Text, out Skeleton.Bones[BoneBox.SelectedIndex].transformData.m12).ToString();

        }

        private void m13_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(m13.Text, out Skeleton.Bones[BoneBox.SelectedIndex].transformData.m13).ToString();

        }

        private void m20_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(m20.Text, out Skeleton.Bones[BoneBox.SelectedIndex].transformData.m20).ToString();

        }

        private void m21_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(m21.Text, out Skeleton.Bones[BoneBox.SelectedIndex].transformData.m21).ToString();

        }

        private void m22_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(m22.Text, out Skeleton.Bones[BoneBox.SelectedIndex].transformData.m22).ToString();

        }

        private void m23_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(m23.Text, out Skeleton.Bones[BoneBox.SelectedIndex].transformData.m23).ToString();

        }

        private void m30_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(m30.Text, out Skeleton.Bones[BoneBox.SelectedIndex].transformData.m30).ToString();

        }

        private void m31_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(m31.Text, out Skeleton.Bones[BoneBox.SelectedIndex].transformData.m31).ToString();

        }

        private void m32_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(m32.Text, out Skeleton.Bones[BoneBox.SelectedIndex].transformData.m32).ToString();

        }

        private void m33_TextChanged(object sender, EventArgs e)
        {
            float.TryParse(m33.Text, out Skeleton.Bones[BoneBox.SelectedIndex].transformData.m33).ToString();

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog browseFile = new OpenFileDialog();
            browseFile.Filter = "Xenoverse Esk File (*.esk)|*.esk";
            browseFile.Title = "Browse for Esk File";
            if (browseFile.ShowDialog() == DialogResult.Cancel)
                return;
            Skeleton = new esk();
            Skeleton.ReadEsk(browseFile.FileName);

            BoneBox.Items.Clear();
            for (int i = 0; i < Skeleton.Bones.Length; i++)
            {
                BoneBox.Items.Add(Skeleton.Bones[i].Name);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Skeleton.WriteEsk();
        }

        private void copyFromEskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog browseFile = new OpenFileDialog();
            browseFile.Filter = "Xenoverse Esk File (*.esk)|*.esk";
            browseFile.Title = "Browse for Esk File";
            if (browseFile.ShowDialog() == DialogResult.Cancel)
                return;

            esk Skeleton2 = new esk();
            Skeleton2.ReadEsk(browseFile.FileName);

            foreach(var i in BoneBox.SelectedIndices)
            {
                for (int j = 0; j < Skeleton2.Bones.Length; j++)
                {
                    if (Skeleton.Bones[(int)i].Name == Skeleton2.Bones[j].Name)
                    {
                        Skeleton.Bones[(int)i].transformData = Skeleton2.Bones[j].transformData;
                        MessageBox.Show("Copy" + Skeleton.Bones[(int)i].Name);
                    }
                }
            }
        }

        private void BoneBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            m00.Text = Skeleton.Bones[BoneBox.SelectedIndex].transformData.m00.ToString();
            m01.Text = Skeleton.Bones[BoneBox.SelectedIndex].transformData.m01.ToString();
            m02.Text = Skeleton.Bones[BoneBox.SelectedIndex].transformData.m02.ToString();
            m03.Text = Skeleton.Bones[BoneBox.SelectedIndex].transformData.m03.ToString();

            m10.Text = Skeleton.Bones[BoneBox.SelectedIndex].transformData.m10.ToString();
            m11.Text = Skeleton.Bones[BoneBox.SelectedIndex].transformData.m11.ToString();
            m12.Text = Skeleton.Bones[BoneBox.SelectedIndex].transformData.m12.ToString();
            m13.Text = Skeleton.Bones[BoneBox.SelectedIndex].transformData.m13.ToString();

            m20.Text = Skeleton.Bones[BoneBox.SelectedIndex].transformData.m20.ToString();
            m21.Text = Skeleton.Bones[BoneBox.SelectedIndex].transformData.m21.ToString();
            m22.Text = Skeleton.Bones[BoneBox.SelectedIndex].transformData.m22.ToString();
            m23.Text = Skeleton.Bones[BoneBox.SelectedIndex].transformData.m23.ToString();

            m30.Text = Skeleton.Bones[BoneBox.SelectedIndex].transformData.m30.ToString();
            m31.Text = Skeleton.Bones[BoneBox.SelectedIndex].transformData.m31.ToString();
            m32.Text = Skeleton.Bones[BoneBox.SelectedIndex].transformData.m32.ToString();
            m33.Text = Skeleton.Bones[BoneBox.SelectedIndex].transformData.m33.ToString();
        }
    }
}
