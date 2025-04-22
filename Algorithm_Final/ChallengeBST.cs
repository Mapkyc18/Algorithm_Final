using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Final
{
    public class ChallengeBST
    {
        class TreeNode
        {
            public int Num;
            public TreeNode Left, Right;
            public TreeNode(int val) { Num = val; }
        }

        TreeNode root;

        public void Insert(int val)
        {
            root = Add(root, val);
        }

        TreeNode Add(TreeNode node, int val)
        {
            if (node == null) return new TreeNode(val);
            if (val < node.Num) node.Left = Add(node.Left, val);
            else node.Right = Add(node.Right, val);
            return node;
        }

        public int FindClosest(int target)
        {
            TreeNode walk = root;
            int close = -1;
            int diff = int.MaxValue;
            while (walk != null)
            {
                int curDiff = Math.Abs(walk.Num - target);
                if (curDiff < diff)
                {
                    diff = curDiff;
                    close = walk.Num;
                }
                walk = target < walk.Num ? walk.Left : walk.Right;
            }
            return close;
        }

        public void Delete(int val)
        {
            root = Remove(root, val);
        }

        TreeNode Remove(TreeNode node, int val)
        {
            if (node == null) return null;
            if (val < node.Num) node.Left = Remove(node.Left, val);
            else if (val > node.Num) node.Right = Remove(node.Right, val);
            else
            {
                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;
                TreeNode minNode = GetMin(node.Right);
                node.Num = minNode.Num;
                node.Right = Remove(node.Right, minNode.Num);
            }
            return node;
        }

        TreeNode GetMin(TreeNode node)
        {
            while (node.Left != null) node = node.Left;
            return node;
        }

    }
}
