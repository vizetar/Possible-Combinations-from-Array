using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SotiQuery
{
    public class Query
    {
        #region input array, output list & temporary list to save combination

        // input array

        //int[] arr = { 1, 2, 3, 4, 5, 6 };
        int[] arr = { 1, 2, 3, 4, 4, 20, 10, 10, 1, 1, 1, 1, 1, 1, 2, 2, 2 };

        // list to save combinations temporarily on every iteration, it will be rest after one iteration of main array
        List<int> list = new List<int>();

        // final list of array to save all combinations, it will be return as a result
        List<int[]> collect = new List<int[]>();

        #endregion

        #region method to get combination equal to sum n, from given array

        public List<int[]> GetCombination(int n)
        {
            int start = 0;
            int sum = 0;
            bool check = true;

            /* apply loop on main array and select each element from it one by one, pass all values to another 
            array except selected element & check combination of that element with all other numbers in array one by one */
            for (int i = 0; i < arr.Length; i++)
            {
                sum = arr[i];
                list.Add(arr[i]);

                #region check whether selected value is equal to sum
                if (sum == n)
                {
                    // to check duplicacy in final list
                    if (collect.Count > 0)
                    {
                        for (int x = 0; x < collect.Count; x++)
                        {
                            if (collect[x].Length == list.Count)
                            {
                                for (int len = 0; len < collect[x].Length; len++)
                                {
                                    int[] chk = collect[x];
                                    if (!list.Exists(f => f.Equals(chk[len])))
                                    {
                                        check = false;
                                        break;
                                    }
                                    else
                                        check = true;
                                }
                                if (check == true)
                                    goto enter;
                            }
                            else
                                check = false;
                        }
                    }
                    else
                    {
                        check = false;
                    }

                    // add distinct combination to final list of array
                    if (check == false)
                    {
                        int[] result = new int[list.Count];
                        for (int res = 0; res < list.Count; res++)
                        {
                            result[res] = list[res];
                        }
                        collect.Add(result);
                        check = true;
                        //break;
                    }

                    goto enter;

                }

                #endregion

                // transfer all data from array to new Array except selected element.
                ArrayList elements = new ArrayList(arr);
                elements.RemoveAt(i);

                /* add elements with selected element one by one & add each element into list and if sum exceeds more 
                then given number increase start value and intialize all paramaters & restart loop skip start-th element value */

                function:
                for(int j=start;j< elements.Count; j++)
                {
                    sum = sum + Convert.ToInt16(elements[j]);
                    if (sum <= n)
                        list.Add(Convert.ToInt16(elements[j]));
                    else
                    {
                        start = start + 1;
                        if (start <= elements.Count)
                        {
                            list.Clear();
                            list.Add(arr[i]);
                            sum = arr[i];
                            goto function;
                        }
                    }
                        
                    // if sum equals given number check duplicacy with final list and add it to final list of array 
                    if (sum == n)
                    {
                        if (collect.Count > 0)
                        {
                            for (int x = 0; x < collect.Count; x++)
                            {
                                if (collect[x].Length == list.Count)
                                {
                                    for (int len = 0; len < collect[x].Length; len++)
                                    {
                                        int[] chk = collect[x];
                                        if (!list.Exists(f => f.Equals(chk[len])))
                                        {
                                            check = false;
                                            break;
                                        }
                                        else
                                          check=  true;
                                    }
                                    if (check == true)
                                        goto duplicacy;
                                }
                                else
                                    check = false;
                            }
                        }
                        else
                        {
                            check = false;
                        }

                        if (check == false)
                        {

                            int[] result = new int[list.Count];
                            for (int res = 0; res < list.Count; res++)
                            {
                                result[res] = list[res];
                            }

                            collect.Add(result);
                            check = true;
                            //break;
                        }

                        duplicacy:
                        start = start + 1;
                        if(start <= elements.Count)
                        {
                            check = true;
                            list.Clear();
                            list.Add(arr[i]);
                            sum = arr[i];
                            goto function;
                        }
                    }
                }

                // initialize all initial paramaters again & proceed to next iteration of first main array.
                enter:
                list.Clear();
                start = 0;
                    sum = 0;
                check = true;
              
            }

            // return final list of array
            return collect;

        }

        #endregion




    }
}
