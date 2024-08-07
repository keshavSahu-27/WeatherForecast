pipeline {
     agent { label 'cloud' }

    stages {
        stage('Initialize') {
            steps {
                script {
                     echo 'Pipeline initializedd'
                }
            }
        }

        stage('Build .NET') {
            steps {
                script {
                 
                    sh 'dotnet build --configuration Release'
                    sh 'dotnet publish --configuration Release --output out'
                }
            }
        }

        stage('Build Angular') {
            steps {
                script {
                    dir('clientApp') {
                        sh 'npm install'
                        sh 'ng build --prod --output-path dist'
                    }
                }
            }
        }

        stage('Archive Artifacts') {
            steps {
                script {
                    archiveArtifacts artifacts: '**/out/**, **/clientApp/dist/**', allowEmptyArchive: true
                }
            }
        }
    }

    post {
        always {
            cleanWs()
        }
        success {
            echo 'Build completed successfully!'
        }
        failure {
            echo 'Build failed!'
        }
    }
}
