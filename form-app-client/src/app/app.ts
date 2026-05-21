import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { FormService } from './form.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})

export class App {
  form = new FormGroup({
    firstName: new FormControl('', Validators.required),
    lastName:  new FormControl('', Validators.required)
  });

  message = '';
  isError = false;
  isLoading = false;        // tracks whether a request is in progress

  constructor(private formService: FormService) {}

  onSubmit(): void {
    if (this.form.valid) {
      this.isLoading = true;
      this.message = '';

      this.formService.submit({
        firstName: this.form.value.firstName!,
        lastName:  this.form.value.lastName!
      }).subscribe({
        next: (res: any) => {
          this.message = res.message;
          this.isError = false;
          this.isLoading = false;
          this.form.reset();
        },
        error: () => {
          this.message = 'Something went wrong. Please try again.';
          this.isError = true;
          this.isLoading = false;
        }
      });
    }
  }
}