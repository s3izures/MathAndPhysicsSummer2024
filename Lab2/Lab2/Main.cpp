#include <iostream>
#include <vector>
#include <string>

void velocityAcceleration();
void motionEquations();
float moEq1();
float moEq2();
float moEq3();
float moEq4();
float moEq5();
void vectorAcceleration();

int main()
{
    velocityAcceleration();
    motionEquations();
    vectorAcceleration();
}

void velocityAcceleration()
{
    // TASK: Write a simple program that will ask for a polynomial that presents the object’s position in timeand returns instantaneous velocity and acceleration in a specified moment.
    int highestOrder = 0;
    std::vector<float> coefficients;
    float input = 0;
    float x = 0;
    float velocity = 0;
    float acceleration = 0;

    // Ask user for highest order
    std::cout << "Enter highest order: ";
    std::cin >> highestOrder;

    //Ask user for coefficients
    for (int i = highestOrder; i >= 0; i--)
    {
        if (i > 1) //higher than x (ex: x^2, x^6)
        {
            std::cout << "Enter coefficient of variable x^" << i << ": ";
        }
        else if (i == 1) //is x
        {
            std::cout << "Enter coefficient of variable x: ";
        }
        else //just a number
        {
            std::cout << "Enter constant variable: ";
        }
        std::cin >> input;
        coefficients.push_back(input);
    }


    //Ask for moment
    std::cout << std::endl << "Enter value of x: ";
    std::cin >> x;


    //Show equation
    std::cout << std::endl << "Equation: ";
    for (int i = highestOrder; i >= 0; i--)
    {
        if (coefficients[highestOrder - i] != 0)
        {
            //print sign if positive
            if (i < highestOrder)
            {
                if (coefficients[highestOrder - i] >= 0)
                {
                    std::cout << "+";
                }
            }

            //print coefficients
            if (i > 1) //higher than x (ex: x^2, x^6)
            {
                std::cout << coefficients[highestOrder - i] << "x^" << i;
            }
            else if (i == 1) //is x
            {
                std::cout << coefficients[highestOrder - i] << "x";
            }
            else //just a number
            {
                std::cout << coefficients[highestOrder - i];
            }
        }
    }


    //Show differentiated equation
    std::cout << std::endl << "Differentiated Equation: ";
    for (int i = highestOrder; i >= 0; i--)
    {
        if (coefficients[highestOrder - i] != 0)
        {
            //print sign if positive, constant is dropped
            if (i < highestOrder && i > 0)
            {
                if (coefficients[highestOrder - i] >= 0)
                {
                    std::cout << "+";
                }
            }

            //print coefficients
            if (i > 2) //higher than x^2 (ex: x^2, x^6)
            {
                //y' = n*x^(n-1)
                std::cout << i * coefficients[highestOrder - i] << "x^" << i - 1;
            }
            else if (i == 2) //is x
            {
                std::cout << i * coefficients[highestOrder - i] << "x";
            }
            else if (i == 1) //constant is dropped
            {
                std::cout << coefficients[highestOrder - i];
            }
        }
    }


    //Calculate velocity
    for (int i = highestOrder; i >= 0; i--)
    {
        if (i > 0)
        {
            velocity += coefficients[highestOrder - i] * powf(x, i);
        }
        else
        {
            velocity += coefficients[highestOrder - i];
        }
    }


    //Calculate acceleration (differentiation of velocity)
    for (int i = highestOrder; i >= 0; i--)
    {
        if (i > 1)
        {
            //y' = n*x^(n-1)
            acceleration += (i * coefficients[highestOrder - i]) * powf(x, i - 1);
        }
        else if (x == 1) // constant is dropped
        {
            acceleration += (i * coefficients[highestOrder - i]);
        }
    }

    std::cout << std::endl;

    //Display velocity and acceleration
    std::cout << "Velocity: " << velocity << std::endl;
    std::cout << "Acceleration: " << acceleration << std::endl;
}

void motionEquations()
{
    //TASK: Create a library of functions using all five equations of motion. Each equation should be used more than once to solve each variable involved.
}
/*  r0 is the particle's initial position
    r is the particle's final position
    v0 is the particle's initial velocity
    v is the particle's final velocity
    a is the particle's acceleration
    t is the time interval */
float moEq1()
{
    //v=at+v0
}
float moEq2()
{
    //r=r0+v0*t+1/2*a*t^2
}
float moEq3()
{
    //r=r0 + 1/2(v+v0)t
}
float moEq4()
{
    //v^2=v0^2+2*a(r-r0)
}
float moEq5()
{
    //r=r0+v*t-1/2*a*t^2
}

void vectorAcceleration()
{
    //TASK: Write a simple program that will ask for an object’s weight and all the forces acting on the object and return the resulting acceleration. (acceleration should be a scalar)
}