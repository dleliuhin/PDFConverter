using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDFConverter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFConverter.Tests
{
    [TestClass()]
    public class FileListViewTests
    {
        [TestMethod()]
        public void NotifyPropertyChanged_Test()
        {
            string path = null;

            FileListView fileListView = new FileListView();

            fileListView.NotifyPropertyChanged(path);
        }

        [TestMethod()]
        public void NotifyPropertyChanged_NotifiesOnNewValue_Test()
        {
            bool eventWasRaised = false;

            FileListView fileListView = new FileListView();

            fileListView.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "CurPath")
                {
                    eventWasRaised = true;
                }
            };

            fileListView.CurPath = "CurPath";

            Assert.IsTrue(eventWasRaised);
        }

        [TestMethod()]
        public void AddNullPath_Test()
        {
            string path = null;

            FileListView fileListView = new FileListView();

            fileListView.AddFilesView(path);
        }

        [TestMethod()]
        public void AddSimplePath_Test()
        {
            string path = "D:\\";

            FileListView fileListView = new FileListView();

            fileListView.AddFilesView(path);
        }

        [TestMethod()]
        public void GetNullPath_Test()
        {
            FileListView fileListView = new FileListView();

            fileListView.CurPath = null;

            string path = fileListView.CurPath;

            Assert.AreEqual(null, path);
        }

        [TestMethod()]
        public void SetNullPath_Test()
        {
            FileListView fileListView = new FileListView();

            fileListView.CurPath = null;

            string path = fileListView.CurPath;

            Assert.AreEqual(null, path);
        }

        [TestMethod()]
        public void SetSimplePath_Test()
        {
            FileListView fileListView = new FileListView();

            fileListView.CurPath = "D:\\";

            string path = fileListView.CurPath;

            string expected = "D:\\";

            Assert.AreEqual(expected, path);
        }
    }

    [TestClass()]
    public class FileItemTests
    {
        [TestMethod()]
        public void GetFileItems_Test()
        {
            FileItem fileItem = new FileItem(0, "name", "format", "date", "ssize");

            var id = fileItem.Id;

            var name = fileItem.Name;

            var format = fileItem.Format;

            var date = fileItem.Date;

            var size = fileItem.Size;

            Assert.AreEqual(0, id);
            Assert.AreEqual("name", name);
            Assert.AreEqual("format", format);
            Assert.AreEqual("date", date);
            Assert.AreEqual("ssize", size);
        }

        [TestMethod()]
        public void NotifyPropertyChanged_NotifiesOnNewValue_Test()
        {
            bool eventWasRaised = false;

            FileItem fileItem = new FileItem(0, "name", "format", "date", "ssize");

            fileItem.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "Size")
                {
                    eventWasRaised = true;
                }
            };

            fileItem.Size = "Size1";

            Assert.IsTrue(eventWasRaised);
        }

    }
}