using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelProject;

namespace QueueingSystem
{
    public partial class QueueingSystemForm : Form
    {
        private (Int32 n1, Int32 n2) SS; // состояние системы
        private Int32 NA; // количество прибывших клиентов к моменту времени t
        private Int32 ND; // количество ушедших клиентов к моменту времени t
        private List<Double> A1 = new List<Double>(); // времена прибытия клиентов
        private List<Double> A2 = new List<Double>(); // времена поступления клиентов на 2 устройство
        private List<Double> D = new List<Double>(); // времена ухода клиентов из системы
        private Double tA; // время следующего прибытия
        private Double t1; // время завершения обслуживания на 1 устройстве
        private Double t2; // время завершения обслуживания на 2 устройстве
        private Double t; // текущее время
        private Double T; // период моделирования
        private const Double lambda = 0.7; // интенсивность
        private bool isModelActive = false;
        private Thread thread; // Поток для моделирования процесса
        private List<Double> QueuePeopleCount = new List<Double>(); // Количество людей в очереди

        public QueueingSystemForm()
        {
            InitializeComponent();
        }

        // Инициализация имитации
        private void InitializeImitation()
        {
            t = 0;
            NA = 0;
            ND = 0;
            SS = (0, 0);
            t1 = 10000000; // имитируем бесконечность
            t2 = 10000000; // имитируем бесконечность
            tA = GenerateComingT(t); // генерируем первое время прихода

            logTextBox.Clear(); // очищаем логи
            averageProcessTimeTextBox.Clear(); // очищаем среднее время обслуживания
            averageTimeInSystemTextBox.Clear(); // очищаем среднее время в системе
            averagePeopleCountTextBox.Clear(); // очищаем среднее число ожидающих клиентов
            averageQueueTextBox.Clear(); // очищаем среднюю задержку

            A1 = new List<Double>();
            A2 = new List<Double>();
            D = new List<Double>();
            QueuePeopleCount = new List<Double>();
        }

        // Генерация времени прихода
        private double GenerateComingT(double currentT)
        {
            while (true)
            {
                double U1 = ModelProject.Program.GenerateRandomU();
                currentT -= 1 / lambda * Math.Log(U1, 2);
                if (currentT > T)
                    break;
                Thread.Sleep(500);
                double U2 = ModelProject.Program.GenerateRandomU();
                if (U2 <= ModelProject.Program.LambdaT(currentT, T) / lambda)
                    return currentT;
            }
            return 10000000;
        }

        // Генерация времени обслуживания
        private double GenerateY()
        {
            double U = ModelProject.Program.GenerateRandomU();
            return -lambda * Math.Log(U);
        }

        private void UpdateLogTextBox(String text)
        {
            logTextBox.Text += text;
            logTextBox.SelectionStart = logTextBox.Text.Length;
            logTextBox.ScrollToCaret();
        }

        private void Case1()
        {
            t = tA;

            if (InvokeRequired)
                Invoke((Action)(() => UpdateLogTextBox("Следующее событие - прибытие клиента. Время: " + Math.Round(t, 4) + Environment.NewLine)));
            else
                UpdateLogTextBox("Следующее событие - прибытие клиента. Время: " + Math.Round(t, 4) + Environment.NewLine);

            NA++;
            SS.n1++;
            tA = GenerateComingT(t);

            if (SS.n1 == 1)
                t1 = t + GenerateY();

            A1.Insert(NA - 1, t);

            int firstQueuePeopleCount = SS.n1 > 0 ? SS.n1 - 1 : 0;
            int secondQueuePeopleCount = SS.n2 > 0 ? SS.n2 - 1 : 0;
            QueuePeopleCount.Add(firstQueuePeopleCount + secondQueuePeopleCount);
        }

        private void Case2()
        {
            t = t1;

            if (InvokeRequired)
                Invoke((Action)(() => UpdateLogTextBox("Следующее событие - поступление клиента на II устройство. Время: " + Math.Round(t, 4) + Environment.NewLine)));
            else
                UpdateLogTextBox("Следующее событие - поступление клиента на II устройство. Время: " + Math.Round(t, 4) + Environment.NewLine);

            SS.n1--;
            SS.n2++;

            if (SS.n1 == 0)
                t1 = 10000000;
            else
                t1 = t + GenerateY();

            Thread.Sleep(200);
            if (SS.n2 == 1)
                t2 = t + GenerateY();

            A2.Insert(NA - SS.n1 - 1, t);

            int firstQueuePeopleCount = SS.n1 > 0 ? SS.n1 - 1 : 0;
            int secondQueuePeopleCount = SS.n2 > 0 ? SS.n2 - 1 : 0;
            QueuePeopleCount.Add(firstQueuePeopleCount + secondQueuePeopleCount);
        }

        private void Case3()
        {
            t = t2;

            if (InvokeRequired)
                Invoke((Action)(() => UpdateLogTextBox("Следующее событие - уход клиента. Время: " + Math.Round(t, 4) + Environment.NewLine)));
            else
                UpdateLogTextBox("Следующее событие - уход клиента. Время: " + Math.Round(t, 4) + Environment.NewLine);

            ND++;
            SS.n2--;

            if (SS.n2 == 0)
                t2 = 10000000;

            if (SS.n2 > 0)
                t2 = t + GenerateY();

            D.Insert(ND - 1, t);

            int firstQueuePeopleCount = SS.n1 > 0 ? SS.n1 - 1 : 0;
            int secondQueuePeopleCount = SS.n2 > 0 ? SS.n2 - 1 : 0;
            QueuePeopleCount.Add(firstQueuePeopleCount + secondQueuePeopleCount);
        }

        private void ChangeButtons()
        {
            startButton.Enabled = !startButton.Enabled;
            startButton.Visible = !startButton.Visible;
            stopButton.Enabled = !stopButton.Enabled;
            stopButton.Visible = !stopButton.Visible;
        }

        /// <summary>
        /// Общий процесс моделирования
        /// </summary>
        private void ModelProcess()
        {
            Action case1 = new Action(Case1);
            Action case2 = new Action(Case2);
            Action case3 = new Action(Case3);

            while ((isModelActive && (t < T)) || (SS.n1 > 0) || SS.n2 > 0)
            {
                double minT = new double[] { t1, t2, tA }.Min();
                if (t1 >= 100000 && t2 >= 100000 && tA >= 100000)
                    break;

                Thread.Sleep(200);
                if (minT == tA)
                    if (InvokeRequired)
                        case1.Invoke();
                    else
                        Case1();

                else if (minT == t1)
                    if (InvokeRequired)
                        case2.Invoke();
                    else
                        Case2();

                else if (minT == t2)
                    if (InvokeRequired)
                        case3.Invoke();
                    else
                        Case3();

                if (InvokeRequired)
                    Invoke((Action)(() => RefreshPictureBox()));
                else
                    RefreshPictureBox();

                Thread.Sleep(1000);
            }

            if (InvokeRequired)
            {
                Invoke((Action)(() => ChangeButtons()));
                Invoke((Action)(() => CalculateAverages()));
            }
            else
            {
                ChangeButtons();
                CalculateAverages();
            }
        }

        private void RefreshPictureBox()
        {
            showPictureBox.Refresh();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeButtons();
                isModelActive = true;
                T = Convert.ToDouble(modelingTimeTextBox.Text);

                showPictureBox.Refresh();
                InitializeImitation();
                thread = new Thread(ModelProcess);
                thread.Start();
            }
            catch
            {
                ChangeButtons();
                MessageBox.Show("Значение периода моделирования имело неверный формат", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            ChangeButtons();
            isModelActive = false;

            thread.Abort();
        }

        private void QueueingSystemForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (thread != null)
                thread.Abort();
            Application.Exit();
        }

        private void showPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int firstDeviceX = showPictureBox.Width / 3;
            int firstDeviceY = 30;
            int secondDeviceX = 2 * showPictureBox.Width / 3;
            int secondDeviceY = 30;

            Pen pen = new Pen(Brushes.DarkCyan, 2);
            g.DrawRectangle(pen, firstDeviceX, firstDeviceY, 30, 30);
            g.DrawRectangle(pen, secondDeviceX, secondDeviceY, 30, 30);

            for (int i = 0; i < SS.n1; i++)
            {
                int currentY = firstDeviceY + 35 * i;
                g.FillEllipse(Brushes.Red, firstDeviceX, currentY, 29, 29);
            }

            for (int i = 0; i < SS.n2; i++)
            {
                int currentY = secondDeviceY + 35 * i;
                g.FillEllipse(Brushes.Red, secondDeviceX, currentY, 29, 29);
            }
        }

        private void CalculateAverages()
        {
            if (A1.Any())
            {
                List<Double> FirstBegins = new List<double>(); // время начала обслуживания на I устройстве
                List<Double> SecondBegins = new List<double>(); // время начала обслуживания на II устройстве
                List<Double> FirstProcess = new List<double>(); // время обслуживания на I устройстве
                List<Double> SecondProcess = new List<double>(); // время обслуживания на II устройстве
                List<Double> CommonProcess = new List<double>(); // общее время обслуживания
                List<Double> CommonInSystem = new List<double>(); // общее время в системе
                List<Double> CommonQueue = new List<double>(); // общее время в очереди

                FirstBegins.Add(A1.First()); // первый клиент сразу поступает на I устройство
                SecondBegins.Add(A2.First()); // первый клиент сразу поступает на II устройство

                // Подсчет времен начала обслуживания клиентов на устройствах
                for (int i = 1; i < A1.Count; i++)
                {
                    FirstBegins.Add(Math.Max(A1[i], A2[i - 1])); // начало обслуживания на I - максимум из времени поступления предыдущего клиента на II устройство и времени прибытия.
                    SecondBegins.Add(Math.Max(A2[i], D[i - 1])); // начало обслуживания на II - максимум из времени ухода предыдущего клиента и времени поступления на II устройство.
                }

                // Подсчет времен обслуживания, ожидания
                for (int i = 0; i < A1.Count; i++)
                {
                    FirstProcess.Add(A2[i] - FirstBegins[i]); // время обслуживания на I - разница между временем поступления на II устройство и временем начала обслуживания на I
                    SecondProcess.Add(D[i] - SecondBegins[i]); // время обслуживания на II - разница между временем ухода и временем начала обслуживания на II устройстве

                    CommonProcess.Add(FirstProcess[i] + SecondProcess[i]); // общее время обслуживания
                    CommonInSystem.Add(D[i] - A1[i]); // общее время в системе - разность между временем ухода и временем прибытия
                    CommonQueue.Add(CommonInSystem[i] - CommonProcess[i]); // общее время ожидания - разность между общим временем в системе и общим временем обслуживания
                }

                averageProcessTimeTextBox.Text = Math.Round(CommonProcess.Sum() / CommonProcess.Count, 4).ToString();
                averageTimeInSystemTextBox.Text = Math.Round(CommonInSystem.Sum() / CommonInSystem.Count, 4).ToString();
                averageQueueTextBox.Text = Math.Round(CommonQueue.Sum() / CommonQueue.Count, 4).ToString();
                averagePeopleCountTextBox.Text = Math.Round(QueuePeopleCount.Sum() / QueuePeopleCount.Count, 4).ToString();
            }
        }
    }
}
