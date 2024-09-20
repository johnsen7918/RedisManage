using System;
using System.Collections.Generic;
using System.Windows.Forms;
using StackExchange.Redis;
public class TreeNodeData
{
	public string Path { get; set; }
	public string DisplayName { get; set; }
	public List<TreeNodeData> Children { get; set; }

	public TreeNodeData(string path, string displayName)
	{
		Path = path;
		DisplayName = displayName;
		Children = new List<TreeNodeData>();
	}

	public static List<TreeNodeData> ParseData(List<string> data)
	{
		var rootNodes = new List<TreeNodeData>();
		foreach (var item in data)
		{
			var parts = item.Split(':');
			var currentPath = "";
			TreeNodeData currentNode = null;
			for (int i = 0; i < parts.Length; i++)
			{
				if (i == 0)
				{
					currentPath = parts[i];
					currentNode = rootNodes.FirstOrDefault(x => x.Path == currentPath);
					if (currentNode == null)
					{
						currentNode = new TreeNodeData(currentPath, parts[i]);
						rootNodes.Add(currentNode);
					}
				}
				else
				{
					currentPath += ":" + parts[i];
					var childNode = currentNode.Children.FirstOrDefault(x => x.Path == currentPath);
					if (childNode == null)
					{
						childNode = new TreeNodeData(currentPath, parts[i]);
						currentNode.Children.Add(childNode);
					}
					currentNode = childNode;
				}
			}
		}
		return rootNodes;
	}

	public static void LoadTree(List<TreeNodeData> nodes, TreeNode parent,int depth)
	{
		foreach (var node in nodes)
		{
			
			var treeNode = new TreeNode(node.DisplayName);
			parent.Nodes.Add(treeNode);
			
			if (node.Children.Any())
			{
				LoadTree(node.Children, treeNode,depth+1);
			}
		}
	}
	
}