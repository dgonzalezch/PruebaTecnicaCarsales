import { Component, input } from '@angular/core';

@Component({
  selector: 'app-loading',
  imports: [],
  template: '<div class="loading">Cargando {{ sectionName() }}...</div>',
  styleUrl: './loading.component.scss'
})
export class LoadingComponent {
  readonly sectionName = input<string>('datos');
}
