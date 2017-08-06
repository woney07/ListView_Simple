using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace ListView_Simple
{
    [Activity(Label = "ListView_Simple", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button btnSearch;
        TextView txtSelected;
        ListView lstView;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            btnSearch = FindViewById<Button>(Resource.Id.btnSearch);
            txtSelected = FindViewById<TextView>(Resource.Id.txtSelected);
            lstView = FindViewById<ListView>(Resource.Id.lstView);

            btnSearch.Click += BtnSearch_Click;
            lstView.ItemClick += LstView_ItemClick;
        }

        private void LstView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            txtSelected.Text = lstView.Adapter.GetItem(e.Position).ToString();
        }

        private void BtnSearch_Click(object sender, System.EventArgs e)
        {
            // 조회
            List<string> list = new List<string>();
            list.Add("안녕하세요");
            list.Add("리스트뷰 어렵지 않아요");
            list.Add("매우 쉽습니다.");

            // Adapter는 화면에 적용하기에 필요한 개체.
            // Adapter는 DataTable 또는 DataSet 역활(!)
            ArrayAdapter<string> ad = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, list);
            // this : Context(화면)
            // 이 ArrayAdapter는... 화면Activity(this)에 뿌려줄 예정이며 ~(2번째 매개변수)형태로 ~(3번째 매개변수)데이터로 채운다.

            // lstView.Adapter에 ad에서 준비한 화면(Activity)에 형태(SimpleListItem1)로 데이터(list)를 연결.
            lstView.Adapter = ad;

        }
    }
}

