﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace double_linked_list
{
    class Node
    {
        /*Node class represents the node of doubly linked list.
         it consist of the information part and links to
         its succeefing and preceeding 
         in terms of next and previous */
        public int noMhs;
        public string name;
        // point to the succeding node
        public Node next;
        //point to the precceding node
        public Node prev;
    }

    class DoubleLinkedList
    {
        Node START;

        //constructor

        public DoubleLinkedList()
        {
            START = null;
        }
        public void addNode()
        {
            int nim;
            string nm;
            Console.WriteLine("\nEnter the roll number of the student: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nEnter the name of the student");
            nm = Console.ReadLine();
            Node newNode = new Node();
            newNode.noMhs = nim;
            newNode.name = nm;

            //check if the list empty
            if (START == null || nim <= START.noMhs)
            {
                if((START!=null)&&(nim== START.noMhs))
                {
                    Console.WriteLine("\nDulpicate number not allowed");
                    return;
                }
                newNode.next = START;
                if (START !=null)
                    START.prev = newNode;
                newNode.prev = null;
                START = newNode;
                return;
            }
            //if the node is to be inserted at between two node
            Node previous, current;
            for (current = previous = START; current != null && nim >= current.noMhs; previous = current, current = current.next)
            {
               if (nim == current.noMhs)
                {
                    Console.WriteLine("\nDulicate roll numbers not allowed");
                    return;
                }
            }
            newNode.next = current;
            newNode.prev = previous;

            if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;
        }
        public bool search(int rollno,ref Node previous, ref Node current)
        {
            for (previous = current = START; current != null && rollno != current.noMhs; previous = current, current = current.next) { }
            return (current != null);
        }
        public bool dellNode(int rollno)
        {
            Node previous, current;
            previous = current = null;
            if (search(rollno, ref previous, ref current) == false)
                return false;
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
