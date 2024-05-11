using System.Collections;

public class TwoSumTask
{
    public int[] TwoSum(int[] nums, int target)
    {
        var length = nums.Length;
        var dict = new SuperDictionary(length);

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

    public class SuperDictionary
    {
        private struct Entry
        {
            public int hashCode;    // Lower 31 bits of hash code, -1 if unused
            public int next;        // Index of next entry, -1 if last
            public int key;           // Key of entry
            public int value;         // Value of entry
        }

        private int[] buckets;
        private Entry[] entries;
        private int count;

        public SuperDictionary(int capacity)
        {
            Initialize(capacity);
        }

        public int this[int key]
        {
            get
            {
                int i = FindEntry(key);

                if (i >= 0)
                    return entries[i].value;

                return default(int);
            }
            set
            {
                Insert(key, value);
            }
        }

        public void Add(int key, int value)
        {
            Insert(key, value);
        }

        public bool ContainsKey(int key)
        {
            return FindEntry(key) >= 0;
        }

        private int FindEntry(int key)
        {
            // девачьки, это придумали гении
            int hashCode = key.GetHashCode() & 0x7FFFFFFF;
            for (int i = buckets[hashCode % buckets.Length]; i >= 0; i = entries[i].next)
            {
                if (entries[i].hashCode == hashCode && entries[i].key == key)
                    return i;
            }

            return -1;
        }

        private void Initialize(int capacity)
        {
            buckets = new int[capacity];

            for (int i = 0; i < buckets.Length; i++)
                buckets[i] = -1;

            entries = new Entry[capacity];
        }

        private void Insert(int key, int value)
        {
            int hashCode = key.GetHashCode() & 0x7FFFFFFF;
            int targetBucket = hashCode % buckets.Length;

            for (int i = buckets[targetBucket]; i >= 0; i = entries[i].next)
            {
                if (entries[i].hashCode == hashCode && entries[i].key == key)
                {
                    entries[i].value = value;
                    return;
                }

            }
            int index;
            // no resize
            index = count;
            count++;

            entries[index].hashCode = hashCode;
            entries[index].next = buckets[targetBucket];
            entries[index].key = key;
            entries[index].value = value;
            buckets[targetBucket] = index;
        }
    }
}