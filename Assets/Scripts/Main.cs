using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Runtime.InteropServices;

namespace DOD_BOOK
{

    public class Main : MonoBehaviour
    {
        public TextMeshProUGUI ResultText;
        public TextMeshProUGUI ButtonText;
        public int NumTests = 20;

        int m_runTest = 0;

        private void Awake()
        {
            ResultText.text = "Ready\n";
        }

        public void RunTest()
        {
            m_runTest = 1;
        }

        private void Update()
        {
            if (m_runTest == 1)
            {
                ResultText.text = "Running\n";
                m_runTest++;
            }
            else if (m_runTest == 2)
            {
                ResultText.text = "Results: \n";

                List<int> IntList = new List<int>();

                for (int i = 0; i < NumTests; i++)
                {
                    IntList.Add(i);
                    ResultText.text += "List Count " + IntList.Count + " List Capacity " + IntList.Capacity + "\n";
                }

                m_runTest++;
            }
        }
    }
}