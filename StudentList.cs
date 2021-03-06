﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class StudentList
    {
        private Student Head { get; set; }
        private Student Tail { get; set; }
        private Student Iter { get; set; }//pointer to a link
        

        //public class sLink
        //{
        //    private Student Value { get; set; }
        //    private Student Next { get; set; }
        //    private Student Previous { get; set; }
        //}

        public class Student
        {
            public Student Next { get; set; }
            public Student Previous { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public Student(string name, int age)
            {
                Name = name;
                Age = age;
            }
            public Student()
            {
                Name = "";
                Age = 0;
            }

        }
        public void InsertHead(Student s)
        {
            if (Head == null)
                Head =Tail= s;

            //Student temp = Head;
            //Head = s;
            //s.Previous = temp;
            Head = Head.Previous = s;
            
        }
        public void InsertTail(Student s)
        {
            
            if (Tail==null)
            {
                Head = Tail = s;
            }
            Tail = Tail.Next = s;


        }
        /// <summary>
        /// delete and return its val. if empty throw exc
        /// </summary>
        /// <returns></returns>
        public Student DeleteHead()
        {
           
            if(Head==null)
            {
                throw new ArgumentOutOfRangeException("Head returned null");
            }
            Student s = new Student
            {
                Name = Head.Name,
                Age = Head.Age
            };
            Head = Head.Next;
            if (Head == null)
            {
                Tail = null;
            }
            else
                Head.Previous = null;
            return s;
        }
        public bool IsEmpty()
        {
            if (Head == null)
                return true;
            else
                return false;
        }
        /// <summary>
        /// return true if student is there
        /// </summary>
        public bool FindKey(string name)
        {
            if (Head == null)
                return false;
            if(Iter==null)
            {
                Iter = Head;
            }
            Student s = Head;
            int i = 0;
            bool wrap = false;
            while (wrap == false || Iter.Next != null)
            {
                if (Iter.Name == name)
                {
                    return true;
                }
                else if (Iter.Next == null && i == 0)
                {
                    Iter = Head;
                    i++;
                }
                else if (Iter.Next == null && i == 1)
                {
                    return false;
                }
                else
                    Iter = Iter.Next;
            }
            return false;
        }
        /// <summary>
        /// deletes first link contains the name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool DeleteKey(string name)
        {
            if (Head == null)
                return false;
            Student ptr = Head;
            Student prev = new Student();

            while (ptr.Next != null)
            {
                if (ptr.Name == name)
                {
                    break;
                }
                else
                    ptr = ptr.Next;
            }
            if (ptr.Next == null)
            {
                return false;
            }

            Student next = ptr.Next;
            prev.Next = next;
            next.Previous = prev;
            if (ptr.Equals(Iter))
            {
                Iter = null;
            }

            return true;




            //try
            //{
            //    if (Head == null)
            //        return false;
            //    Student s = Head;
            //    for (int i = 0; i < Count; i++)
            //    {
            //        if(s.Name==name)
            //        {
            //            break;
            //        }
            //        s = s.Previous;
            //    }
            //    Student prev = s.Previous;
            //    Student next = s.Next;
            //    prev.Next = next;
            //    next.Previous = next;
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }

    }
}
