import { Component, OnInit, ChangeDetectorRef, ChangeDetectionStrategy   } from '@angular/core';
import { FizzBuzzService } from './fizz-buzz.service';







@Component({
  selector: 'app-fizzbuzz',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
 
})
export class AppComponent implements OnInit {
  seriesFB: any;
  randomNumber!: number;
  limit!: number;
  fizzColor!: string;
  buzzColor!: string;
 
  constructor(private fizzBuzzService: FizzBuzzService, private cdr: ChangeDetectorRef) { }

  ngOnInit(): void {}


  ngAfterContentInit ()
 {
    this.generateRandom();
   
  }

  generateSeries(): void {

  if (this.randomNumber < this.limit) {
      this.fizzBuzzService.getFizzBuzzSeries(this.randomNumber, this.limit).subscribe((series: any) => {
        this.seriesFB = series;
      });
      
    }
    this.fizzColor = this.getRandomColor();
    this.buzzColor = this.getRandomColor();
   

  }


  generateRandom(min =1, max=100) {
    this.randomNumber= Math.floor(Math.random() * (max - min + 1)) + min;
    if (this.randomNumber< this.limit)
      {this.generateSeries()}
      else 
      this.seriesFB= []
    
  }
   
  


  isNumber(val: any): boolean { return typeof val === 'number'; }





  getSquareColor(number: number | string) : any {
 
    if (number === 'fizz') {
      return this.fizzColor;
    } else if (number === 'buzz') {
      return this.buzzColor;
    } else if (number === 'fizzbuzz') {
      return this.getGradient(number);
    } else {
      return this.getRandomColor();
    }
  
}
getGradient(element: any): any {
 
   return `linear-gradient(to right, ${this.fizzColor}, ${this.buzzColor})`;
    
  }



  getRandomColor(): string {
    const letters = '0123456789ABCDEF';
    let color = '#';
    for (let i = 0; i < 6; i++) {
      color += letters[Math.floor(Math.random() * 16)];
    }

    return color;
  }

 
}
