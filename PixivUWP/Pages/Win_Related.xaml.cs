﻿using Pixeez.Objects;
using PixivUWP.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace PixivUWP.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Win_Related : Windows.UI.Xaml.Controls.Page, IBackable
    {
        ItemViewList<Work> list = new ItemViewList<Work>();
        public Win_Related()
        {
            this.InitializeComponent();
            //list.LoadingMoreItems += List_LoadingMoreItems;
            //list.HasMoreItemsEvent += List_HasMoreItemsEvent;
            MasterListView.ItemsSource = list;
            mdc.MasterListView = MasterListView;
        }

        private async Task firstLoadAsync()
        {
            while (scrollRoot.ScrollableHeight - 500 <= 10)
                if (await loadAsync() == false)
                    return;
        }

        bool _isLoading = false;
        private async Task<bool> loadAsync()
        {
            if (_isLoading) return true;
            Debug.WriteLine("loadAsync() called.");
            _isLoading = true;
            try
            {
                var root = nexturl == null ? await Data.TmpData.CurrentAuth.Tokens.GetRelatedWorks(Work.Id.Value) : await Data.TmpData.CurrentAuth.Tokens.AccessNewApiAsync<RecommendedRootobject>(nexturl);
                nexturl = root.next_url ?? string.Empty;
                foreach (var one in root.illusts)
                {
                    if (!list.Contains(one, Data.WorkEqualityComparer.Default))
                        list.Add(one);
                }
                _isLoading = false;
                return true;
            }
            catch
            {
                _isLoading = false;
                return false;
            }
        }

        //private void List_HasMoreItemsEvent(ItemViewList<Work> sender, PackageTuple.WriteableTuple<bool> args)
        //{
        //    args.Item1 = nexturl != string.Empty;
        //}
        Work Work;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Work = e.Parameter as Work;
            var result = firstLoadAsync();
        }
        string nexturl = null;
        //private async void List_LoadingMoreItems(ItemViewList<Work> sender, Tuple<Yinyue200.OperationDeferral.OperationDeferral<uint>, uint> args)
        //{
        //    var nowcount = list.Count;
        //    try
        //    {
        //        var root = nexturl == null ? await Data.TmpData.CurrentAuth.Tokens.GetRelatedWorks(Work.Id.Value) : await Data.TmpData.CurrentAuth.Tokens.AccessNewApiAsync<RecommendedRootobject>(nexturl);
        //        nexturl = root.next_url ?? string.Empty;
        //        foreach (var one in root.illusts)
        //        {
        //            if (!list.Contains(one, Data.WorkEqualityComparer.Default))
        //                list.Add(one);
        //        }
        //    }
        //    catch
        //    {
        //        nexturl = string.Empty;
        //    }
        //    finally
        //    {
        //        args.Item1.Complete((uint)(list.Count - nowcount));
        //    }
        //}

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void MasterListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            mdc.MasterListView_ItemClick(typeof(DetailPage.WorkDetailPage), e.ClickedItem);
        }

        public bool GoBack()
        {
            return ((IBackable)mdc).GoBack();
        }

        double _originHeight = 0;
        private void scrollRoot_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            if (scrollRoot.VerticalOffset == _originHeight) return;
            _originHeight = scrollRoot.VerticalOffset;
            if (scrollRoot.VerticalOffset <= scrollRoot.ScrollableHeight - 500) return;
            var result = loadAsync();
        }
    }
}
