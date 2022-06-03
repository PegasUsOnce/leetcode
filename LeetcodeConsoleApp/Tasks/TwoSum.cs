using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeetcodeConsoleApp.Tasks
{
    public class TwoSum
    {

        //Runtime: 288 ms, faster than 16.16% of C# online submissions for Two Sum.
        //Memory Usage: 42.6 MB, less than 89.64% of C# online submissions for Two Sum.
        public int[] Solution1 (int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                var idx = FindIndex(nums, i, target - nums[i]);
                if (idx != -1)
                    return new[] { i, idx };
            }

            return nums;
        }

        private int FindIndex(int[] nums, int start, int value)
        {
            for (int i = start + 1; i < nums.Length; i++)
                if (nums[i] == value)
                    return i;

            return -1;
        }

        //Runtime: 235 ms, faster than 36.79% of C# online submissions for Two Sum.
        //Memory Usage: 42.4 MB, less than 97.40% of C# online submissions for Two Sum.
        public int[] Solution2(int[] nums, int target)
        {
            var length = nums.Length;
            for (int i = 0; i < length; i++)
            {
                var value = target - nums[i];
                for (int j = i + 1; j < length; j++)
                    if (nums[j] == value)
                        return new[] { i, j };
            }

            return nums;
        }

        //Runtime: 132 ms, faster than 99.62% of C# online submissions for Two Sum.
        //Memory Usage: 44.9 MB, less than 8.74% of C# online submissions for Two Sum.
        public int[] Solution3(int[] nums, int target)
        {
            var length = nums.Length;
            var dict = new Dictionary<int, int>(length);
            for (int i = 0; i < length; i++)
            {
                var value = target - nums[i];
                if (dict.ContainsKey(value))
                    return new[] { i, dict[value] };

                if (!dict.ContainsKey(nums[i]))
                    dict.Add(nums[i], i);
            }

            return nums;
        }

        public void Test()
        {
            int[] nums = { 2, 7, 11, 15 };
            var target = 9;
            int[] expected = { 0, 1 };

            var actual = Solution4(nums, target);
            var act = actual.ToList();
            var exp = expected.ToList();
            if (actual.Length != 2)
                throw new Exception();

            foreach (var a in act)
                if (!exp.Contains(a))
                    throw new Exception();
        }
    }
}
