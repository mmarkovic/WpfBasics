﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchStationView.cs" company="bbv Software Services AG">
//   Copyright (c) 2012
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// <summary>
//   Interaction logic for SearchStationView
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.Modules.SearchStationModule.Content
{
    using System.ComponentModel.Composition;
    using System.Windows.Controls;

    [Export]
    public partial class SearchStationView : UserControl
    {
        public SearchStationView()
        {
            this.InitializeComponent();
        }

        [Import]
        public SearchStationViewModel ViewModel
        {
            set
            {
                this.DataContext = value;
            }
        }

        protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            var searchStationViewModel = this.DataContext as ISearchStationViewModel;
            if (searchStationViewModel != null)
            {
                searchStationViewModel.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == "StationPosition" && searchStationViewModel.StationPosition != null)
                    {
                        this.map.SetView(searchStationViewModel.StationPosition, this.map.ZoomLevel);
                    }
                };
            }
        }
    }
}
