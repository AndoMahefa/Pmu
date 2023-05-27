using System.Drawing.Drawing2D;

namespace PMU;

public partial class Piste : Panel {
    private System.Windows.Forms.Timer timer; 
    Cheval [] chevaux;
    public Piste() {
        this.Size = new System.Drawing.Size(1000, 505);
        this.Location = new Point(0, 0);
        this.BorderStyle = BorderStyle.FixedSingle;
        this.BackColor = Color.DarkGreen;

        this.chevaux = new Cheval[10];
        chevaux[0] = new Cheval(225, 60, 2, 5, Color.Azure);
        chevaux[1] = new Cheval(225, 60, 3, 5, Color.Orange);
        chevaux[2] = new Cheval(225, 60, 4, 5, Color.Blue);
        chevaux[3] = new Cheval(225, 60, 5, 5, Color.Black);
        chevaux[4] = new Cheval(225, 60, 1, 5, Color.Brown);
        chevaux[5] = new Cheval(225, 60, 3, 5, Color.Azure);
        chevaux[6] = new Cheval(225, 60, 2, 5, Color.Orange);
        chevaux[7] = new Cheval(225, 60, 4, 5, Color.Blue);
        chevaux[8] = new Cheval(225, 60, 5, 5, Color.Black);
        chevaux[9] = new Cheval(225, 60, 2, 5, Color.Brown);

        this.InitTimer();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        GraphicsPath path = new GraphicsPath();
        
        path.StartFigure();
        path.AddArc(new Rectangle(0, 0, 350, 500), 90, 180);
        path.AddArc(new Rectangle(600, 0, 350, 500), 270, 180);
        path.CloseFigure();

        GraphicsPath path1 = new GraphicsPath();
        
        path1.StartFigure();
        path1.AddArc(new Rectangle(100, 80, 250, 350), 90, 180);
        path1.AddArc(new Rectangle(600, 80, 250, 350), 270, 180);
        path1.CloseFigure();

        e.Graphics.DrawPath(new Pen(Color.Black, 3), path);
        e.Graphics.DrawPath(new Pen(Color.Black, 3), path1);
        e.Graphics.DrawLine(new Pen(Color.White), new Point(225 , 90), new Point(725, 90));
        e.Graphics.DrawLine(new Pen(Color.White), new Point(100 , 255), new Point(850, 255));
        e.Graphics.DrawLine(new Pen(Color.White), new Point(225 , 420), new Point(725, 420));


        foreach (Cheval c in this.chevaux) c.draw(e);

        // path.AddLine(new Point(200,0), new Point(400, 0));
        // path.AddLine(new Point(200,200), new Point(400, 200));
    }

    public void InitTimer() {
        this.timer = new System.Windows.Forms.Timer();
        this.timer.Interval = 1;
        this.timer.Tick += Timer_tick;
        this.DoubleBuffered = true;
        this.timer.Start();
    }
    public void Timer_tick(Object sender, EventArgs e) {
        if(sender != null) {
            foreach (Cheval c in this.chevaux) c.move();
        }
        this.Invalidate();
        Refresh();
    }
}