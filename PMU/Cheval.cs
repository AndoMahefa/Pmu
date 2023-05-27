using System.Drawing.Drawing2D;


namespace PMU;

public partial class Cheval : Panel {
    // int x = 225;
    float x;
    float y;
    float width = 20;
    float height = 20;
    float speed;
    float endurance;
    float ballRadius;
    float angle = 0;  
    float rotationSpeed;


    Point ballCenter;
    Color color;
    public Cheval(int x, int y, int speed, int endurance, Color color) {
        this.x = x;
        this.y = y;
        this.speed = speed;
        this.endurance = endurance;
        this.color = color;

        // Initialiser les paramètres de la balle
        this.ballRadius = 50;
        // this.ballCenter = new Point(this.x + width / 2, this.y + height / 2);
        // this.angle = 0;
        // this.rotationSpeed = 2;

    }

    public void draw(PaintEventArgs e) {
        Brush brush = new SolidBrush(this.color);
        Rectangle rect = new Rectangle((int)this.x, (int)this.y, (int)this.width, (int)this.height);

        e.Graphics.FillEllipse(brush, rect);
    }

    public void move() {
        if(this.x < 195 || this.x >= 705) {
            this.x += (float) (Math.Cos(angle)*2);
            this.y += (float) (Math.Sin(angle)*2);
            // this.x =  (int)(Math.Cos(angle) * (this.x + this.width / 2 - ballRadius));
            // this.y =  (int)(Math.Sin(angle) * (this.y + this.height / 2 - ballRadius));
            // Mettre à jour l'angle de rotation
            // this.angle = this.angle + (float)0.01;
            angle += 1 * (float)Math.PI / 290;

        } else {
            this.x += this.speed * (float) Math.Cos(angle);
        }
    }

}