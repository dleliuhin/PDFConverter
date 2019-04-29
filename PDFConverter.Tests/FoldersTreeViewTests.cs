using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace PDFConverter.Tests
{
    [TestClass]
    public class FoldersTreeViewTests
    {
        [TestMethod]
        public void GetFullPath_Test()
        {
            FoldersTreeView foldersTreeView = new FoldersTreeView();

            var path = foldersTreeView.getFullPath();
        }

        [TestMethod]
        public void LoadNullTreeView_Test()
        {
            typeof(FoldersTreeView).GetMethod("LoadTreeView", BindingFlags.Instance | 
                BindingFlags.NonPublic).Invoke(new FoldersTreeView(), null);
        }

        [TestMethod]
        public void GetNullFileFolderName_Test()
        {
            string path = null;

            FoldersTreeView.GetFileFolderName(path);
        }

        [TestMethod]
        public void GetSimpleFileFolderName_Test()
        {
            string path = "D:\\";

            FoldersTreeView.GetFileFolderName(path);
        }

        [TestMethod]
        public void GetWithoutBackslashFileFolderName_Test()
        {
            string path = "D:";

            FoldersTreeView.GetFileFolderName(path);
        }
    }
}
