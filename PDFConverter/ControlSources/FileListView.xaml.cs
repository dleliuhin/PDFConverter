/*!
 * @file FileListView.xaml.cs
 * 
 * @author Dmitrii Leliuhin dleliuhin@mail.ru
 * 
 * @date 20.01.2019 5:31:38
 * 
 * @todo 
 * 1. Create Main Form.
 * 
 * @bug No known bugs.
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
//using System.Windows.Shapes;

namespace PDFConverter
{
    /*! \class FileListView
     *  \brief Interaction logic for FileListView.xaml.
     */
    public partial class FileListView : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<FileItem> _fileItems = new ObservableCollection<FileItem>();

        public ObservableCollection<FileItem> fileItems
        {
            get { return _fileItems; }
        }

        public FileListView()
        {
            InitializeComponent();

            this.filesListView.ItemsSource = fileItems;

            //fileItems.Add(new FileItem(0, "name", "format", "date", "ssize"));
        }

        private static string curPath;

        public string CurPath
        {
            get { return curPath; }

            set
            {
                if (value != curPath)
                {
                    curPath = value;

                    this.NotifyPropertyChanged("CurPath");

                    fileItems.Add(new FileItem(0, "name", "format", "date", "ssize"));

                    //AddFilesView(curPath);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string info)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

        public void AddFilesView(string path)
        {
            if (path != null)
            {
                if (!this.filesListView.Items.IsEmpty)
                {
                    fileItems.Clear();                    
                }

                string[] files = Directory.GetFiles(path, "*.pdf");

                var count = 0;

                foreach (var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);

                    var id = count;

                    var name = Path.GetFileNameWithoutExtension(file);

                    var format = fileInfo.Extension;

                    var date = fileInfo.CreationTime.ToString();

                    var size = fileInfo.Length;

                    // Convert size from bytes to kilobytes if need.
                    if (size > 1024)
                    {
                        size = size / 1024;
                    }

                    var ssize = size.ToString();

                    count++;

                    fileItems.Add(new FileItem(id, name, format, date, ssize));
                }
            }
        }
    }

    public class FileItem : INotifyPropertyChanged
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }

            set
            {
                _Id = value;
                this.NotifyPropertyChanged("Id");
            }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }

            set
            {
                _Name = value;
                this.NotifyPropertyChanged("Name");
            }
        }

        private string _Format;

        public string Format
        {
            get { return _Format; }

            set
            {
                _Format = value;
                this.NotifyPropertyChanged("Format");
            }
        }

        private string _Date;

        public string Date
        {
            get { return _Date; }

            set
            {
                _Date = value;
                this.NotifyPropertyChanged("Date");
            }
        }

        private string _Size;

        public string Size
        {
            get { return _Size; }

            set
            {
                _Size = value;
                this.NotifyPropertyChanged("Size");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string info)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public FileItem(int id, string name, string format, string date, string size)
        {
            this.Id = id;
            this.Name = name;
            this.Format = format;
            this.Date = date;
            this.Size = size;
        }
    }
}
