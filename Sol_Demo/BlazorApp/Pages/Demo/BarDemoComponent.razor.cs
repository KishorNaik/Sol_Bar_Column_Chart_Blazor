using BarChart;
using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Pages.Demo
{
    public partial class BarDemoComponent
    {
        #region Private Element Ref Property

        private BarChartComponent BarStudentMark { get; set; }

        #endregion Private Element Ref Property

        #region Private Property

        private bool IsLoad { get; set; }

        private List<BarChartResultSet> BarChartResultSets { get; set; }

        #endregion Private Property

        #region Private Members

        private Task<List<StudentModel>> GetStudentDataAsync()
        {
            return Task.Run(() =>
            {
                var studentListObj = new List<StudentModel>();

                studentListObj.Add(new StudentModel() { StudentName = "Kishor", Marks = 35 });
                studentListObj.Add(new StudentModel() { StudentName = "Mahesh", Marks = 80 });
                studentListObj.Add(new StudentModel() { StudentName = "Sharmila", Marks = 98 });
                studentListObj.Add(new StudentModel() { StudentName = "Eshaan", Marks = 90 });
                studentListObj.Add(new StudentModel() { StudentName = "Jyoti", Marks = 70 });
                studentListObj.Add(new StudentModel() { StudentName = "Yogesh", Marks = 65 });

                return studentListObj;
            });
        }

        private Task BindBarChartAsync(List<StudentModel> studentModels)
        {
            return Task.Run(() =>
            {
                var data =
                        studentModels
                        ?.Select((studentModel) => new BarChartResultSet()
                        {
                            key = studentModel.StudentName,
                            value = studentModel.Marks
                        })
                        ?.ToList();

                this.BarChartResultSets = data;
            });
        }

        #endregion Private Members

        #region Event Handler

        private async Task OnDisplayStudentChart()
        {
            var studentListData = await this.GetStudentDataAsync();

            await this.BindBarChartAsync(studentListData);

            base.StateHasChanged();

            await this.BarStudentMark.SetBarChartAsync();
        }

        #endregion Event Handler

        #region Protected Member

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                IsLoad = true;
                base.StateHasChanged();
            }
        }

        #endregion Protected Member
    }
}