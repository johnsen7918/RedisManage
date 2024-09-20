using Newtonsoft.Json;
using StackExchange.Redis;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RedisManage
{
	public partial class Form1 : Form
	{
		RedisHelper redisHelper = new RedisHelper(3);
		List<RedisKey> redisKeys = new List<RedisKey>();
		string SearchKey = "*";
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			var listKey = redisHelper.KeysSearch(SearchKey,0);
			redisKeys = listKey.OrderBy(x => x.ToString()).ToList();			
			var TreeNode = new TreeNode();			
			List<string> listKeys=redisKeys.Where(x=>x.ToString()!= "DataProtection-Keys").Select(x => x.ToString()).ToList();			
			var rootNodeList = TreeNodeData.ParseData(listKeys);						
			var treeNode = new TreeNode();
			TreeNodeData.LoadTree(rootNodeList, treeNode,0);
			treeRedisList.Nodes.Add(treeNode);		
		}

		private void LoadTreeNodes(TreeNode parentNode, List<string> listKey)
		{
			var groupkeys=listKey.Select(x => x.Split(':')[0]).GroupBy(x=>x).ToList();
			// 遍历子目录并添加到父节点下
			foreach (var item in groupkeys)
			{
				if (item.Key.ToString() == "DataProtection-Keys")
					continue;
				TreeNode node = new TreeNode(item.Key);
				parentNode.Nodes.Add(node);
				LoadChildTreeNodes(parentNode, item.Key);
			}
		}
		private void LoadChildTreeNodes(TreeNode parentNode, string key)
		{
			if (key.Contains(':'))
			{
				var childkey = key.Split(':')[0];
				TreeNode node = new TreeNode(childkey);
				parentNode.Nodes.Add(node);
				LoadChildTreeNodes(node, key.Substring(childkey.Length + 1));
			}
			else
			{
				TreeNode node = new TreeNode(key);
				parentNode.Nodes.Add(node);
			}

		}
		private void treeRedisList_AfterExpand(object sender, TreeViewEventArgs e)
		{
			TreeNode node = e.Node;

			if (node.Nodes.Count == 0)
			{
				var childlist = redisKeys.Where(x => x.ToString().StartsWith(node.Text.ToString().Split(":")[0])).Select(x=>x.ToString()).ToList();
				LoadTreeNodes(node, childlist);
			}
		}

		private void treeRedisList_Click(object sender, EventArgs e)
		{

		}

		private void treeRedisList_AfterSelect(object sender, TreeViewEventArgs e)
		{
			var itemKey = treeRedisList.SelectedNode.FullPath.Trim('\\').Replace("\\", ":");
			lblKeyName.Text = itemKey;
			string redisContent = "";
			try
			{
				redisContent = redisHelper.StringGet(itemKey);
			}
			catch
			{
				redisContent = redisHelper.ListRange(itemKey);
			}
			rtbRedisContent.Text = redisContent;
		}

		private void btnDelRedis_Click(object sender, EventArgs e)
		{
			var msg = MessageBox.Show("确认要删除吗？", "缓存删除确认提示", MessageBoxButtons.OKCancel);
			if (msg == DialogResult.OK)
			{
				var listKey = redisHelper.KeysSearch("*", 0);
				redisKeys = listKey.Where(x => x.ToString().StartsWith(lblKeyName.Text)).ToList();
				var listKeys= redisKeys.Select(x=>x.ToString()).ToList();
				var relbatch=redisHelper.KeyDelete(listKeys);
				bool rel = redisHelper.KeyDelete(lblKeyName.Text.Trim());
				if (rel|| relbatch>0)
				{
					MessageBox.Show("删除成功");
					treeRedisList.Nodes.Clear();
					this.Form1_Load(sender, e);
				}
				else
					MessageBox.Show("删除失败");
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			string key = txtKey.Text;
			if (string.IsNullOrEmpty(key))
			{
				SearchKey = "*";
				treeRedisList.Nodes.Clear();
				this.Form1_Load(sender, e);
			}
			else
			{
				SearchKey=$"*{key}*";
				treeRedisList.Nodes.Clear();
				this.Form1_Load(sender, e);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			redisHelper.FlushDB();
			
		}
	}

	public class RedisList
    {
        public int row { set; get; }
        public ListModel value { get; set; }
    }
    public class ListModel
    {

        //{"Keyword":"CA064C104K4RACTU","UserId":0,"Ip":"::1","MacAddr":null,"AddDate":"2024-04-10T14:50:30.8454678+08:00","PlatformType":1,"SearchType":2,"Id":0}
        public string Keyword { set; get; }
        public int UserId { set; get; }
        public string Ip { set; get; }
        public string MacAddr { set; get; }
        public string AddDate { get; set; }
        public int PlatformType { set; get; }
        public int SearchType { set; get; }
        public int Id { set; get; }

    }
}